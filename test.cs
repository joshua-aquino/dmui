using Godot;
using System;

public class test : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private Node char1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        char1 = this.GetChild(0);
    }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
      if(Input.IsActionJustReleased("test_button_j")) {
          GD.Print("j");
          char1.Call("nextFrame", true);
      }
      if(Input.IsActionJustReleased("test_button_k")) {
          GD.Print("k");
          char1.Call("nextFrame", false);
      }
  }
}
