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
      if(Input.IsActionJustReleased("set_frame_neutral")) {
          char1.Call("setFrame", 0);
      }
      if(Input.IsActionJustReleased("set_frame_cheeky")) {
          char1.Call("setFrame", 1);
      }
      if(Input.IsActionJustReleased("set_frame_peeved")) {
          char1.Call("setFrame", 2);
      }
      if(Input.IsActionJustReleased("set_frame_happy")) {
          char1.Call("setFrame", 3);
      }
      if(Input.IsActionJustReleased("set_frame_sad")) {
          char1.Call("setFrame", 4);
      }
      if(Input.IsActionJustReleased("set_frame_angry")) {
          char1.Call("setFrame", 5);
      }
      if(Input.IsActionJustReleased("test_button_j")) {
          char1.Call("nextFrame", false);
      }
      if(Input.IsActionJustReleased("test_button_k")) {
          char1.Call("nextFrame", true);
      }
  }
}
