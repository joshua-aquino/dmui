using Godot;
using System;

public class window : NinePatchRect
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    
    private Node label;
    [Export]
    private string labelName = "Template";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        label = this.GetNode("Label");
        label.Set("text", labelName);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
