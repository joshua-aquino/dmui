using Godot;
using System;

public class rangerEntry : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export]
	private string entryName = "defaultName";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Set("text", entryName);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
