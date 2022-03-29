using Godot;
using System;

public class character : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private string name;
    private string spriteSheet;
    private byte spriteFrame = 0; // default is neutral, or 0
    private string defaultTheme;
    private string defaultCombatTheme;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}