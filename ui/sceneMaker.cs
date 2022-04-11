using Godot;
using System;
using System.IO;

public class sceneMaker : HBoxContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private string FILEPATH = "./files";
    private Node pane2;
    private PackedScene entryScene;
    private string currFilePath;
    private string[] currEntries;
    private string[] prevEntries;
    private string[] nextEntries;
    private string selectedEntry;
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        currEntries = System.IO.Directory.GetFileSystemEntries(FILEPATH);
        prevEntries = currEntries;
        GD.Print(currEntries);
        GD.Print(prevEntries);

        pane2 = this.GetChild(1).GetChild(0);
        entryScene = (PackedScene)ResourceLoader.Load("res://ui/rangerEntry.tscn");
        Label newEntryScene = (Label)entryScene.Instance();
        pane2.AddChild(newEntryScene);
        newEntryScene = (Label)entryScene.Instance();
        pane2.AddChild(newEntryScene);
        newEntryScene = (Label)entryScene.Instance();
        pane2.AddChild(newEntryScene);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
