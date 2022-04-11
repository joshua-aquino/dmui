using Godot;
using System;
using System.IO;

public class sceneMaker : HBoxContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private string FILEPATH = "./files";
    private Node pane1, pane2;
    private PackedScene entryScene;
    private Button newEntryScene;
    private string currFilePath;
    private string[] currEntries;
    private string[] prevEntries;
    private string[] nextEntries;
    private int selectedEntry = 0;
    
    private void printPane(Node pane, string[] entries)
    {
        foreach (string entry in entries) 
        {
            newEntryScene = (Button)entryScene.Instance();
            newEntryScene.Set("entryName", entry);
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
                }
            break;
            case 2 : //up k
                if (selectedEntry > currEntries.GetLowerBound(0))
                {
                    selectedEntry--;
                    pane2.GetChild(selectedEntry).Call("grab_focus");
                }
            break;
            case 3 : //right l
            break;
        }
    }
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        pane1 = this.GetChild(0).GetChild(0);
        pane2 = this.GetChild(1).GetChild(0);
        entryScene = (PackedScene)ResourceLoader.Load("res://ui/rangerEntry.tscn");
        currEntries = System.IO.Directory.GetFileSystemEntries(FILEPATH);
        prevEntries = currEntries;
        
        printPane(pane1, prevEntries);
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
  }
}
