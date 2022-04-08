using Godot;
using System;

public class sceneView : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    
    private Node textureRect; 
    private string background;
    private Texture texture = ResourceLoader.Load("res://files/backgrounds/winter-woods.jpg") as Texture;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        textureRect = this.GetNode("TextureRect");
        GD.Print(textureRect.Get("flip_v"));
    }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
    if(Input.IsActionJustReleased("apply_preview")) {
        textureRect.Call("set_texture", texture);
        GD.Print(textureRect);
        GD.Print(texture);
    }
  }
}
