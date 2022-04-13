using Godot;
using System;
using System.IO;
using System.Linq;
using System.Timers;

public class sceneMaker : HBoxContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private string FILEPATH = "./files";
    private Node pane1, pane2, pane3;
    private PackedScene entryScene;
    private Button newEntryScene;
    private string currFilePath;
    private string[] currEntries, prevEntries, nextEntries;
    private int selectedEntry = 0;
    private System.Timers.Timer timer;
    private void enterEntry() {
        prevEntries = currEntries;
        currEntries = nextEntries;
        printPane(pane1, prevEntries);
        printPane(pane2, currEntries);
        printPane(pane3, nextEntries);
        selectedEntry = 0;
        pane2.GetChild(selectedEntry).Call("grab_focus");
    }
    private void previewEntry() {
        FileAttributes attr = System.IO.File.GetAttributes(currEntries[selectedEntry]);
        if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
            GD.Print("Its a directory");
            nextEntries = System.IO.Directory.GetFileSystemEntries(currEntries[selectedEntry]);
            printPane(pane3, nextEntries);
        } else {
            GD.Print("Its a file");
            nextEntries = new string[2]{"is", "file"};
            printPane(pane3, nextEntries);
        }
    }
    private void timedPreview()
    {
        if (!timer.Enabled)
        {
            previewEntry();
            timer.Dispose();
            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += ( sender, e ) => { timer.Dispose(); };
            timer.Start();
        } else {
            timer.Dispose();
            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += ( sender, e ) => { 
                timer.Dispose();
                previewEntry();
            };
            timer.Start();           
        }
    }
    
    private void printPane(Node pane, string[] entries)
    {
        foreach (Node n in pane.GetChildren()) {
            pane.Call("remove_child", n);
            n.Free();
        }
        foreach (string entry in entries) 
        {
            newEntryScene = (Button)entryScene.Instance();
            newEntryScene.Set("entryName", entry.Split('/').Last());
            pane.AddChild(newEntryScene);
        }
    }
    private void traverseEntry(byte direction) // 0123 hjkl
    {
        switch(direction) 
        {
            case 0 : //left h
            break;
            case 1 : //down j
                if (selectedEntry < currEntries.GetUpperBound(0))
                {
                    selectedEntry++;
                    pane2.GetChild(selectedEntry).Call("grab_focus");
                    timedPreview();
                }
            break;
            case 2 : //up k
                if (selectedEntry > currEntries.GetLowerBound(0))
                {
                    selectedEntry--;
                    pane2.GetChild(selectedEntry).Call("grab_focus");
                    timedPreview();
                }
            break;
            case 3 : //right l
                enterEntry();
            break;
        }
    }
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        timer = new System.Timers.Timer();
        timer.Interval = 500;
		timer.Elapsed += ( sender, e ) => { timer.Close(); };
        pane1 = this.GetChild(0).GetChild(0);
        pane2 = this.GetChild(1).GetChild(0);
        pane3 = this.GetChild(2).GetChild(0);
        entryScene = (PackedScene)ResourceLoader.Load("res://ui/rangerEntry.tscn");
        currEntries = System.IO.Directory.GetFileSystemEntries(FILEPATH);
        nextEntries = new string[2]{"bob", "carl"};
        
        printPane(pane2, currEntries);
        
        pane2.GetChild(selectedEntry).Call("grab_focus");

        
        GD.Print(currEntries);
        GD.Print(prevEntries);

    }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
    if(Input.IsActionJustPressed("next_entry")) {
        traverseEntry(1);
    }
    if(Input.IsActionJustPressed("previous_entry")) {
        traverseEntry(2);
    }
    if(Input.IsActionJustPressed("in_entry")) {
        traverseEntry(3);
    }
  }
}
