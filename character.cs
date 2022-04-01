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
    private Node sprite;
    private byte maxFrames = 1;
    private string defaultTheme;
    private string defaultCombatTheme;
    
    public void nextFrame(bool nextNotPrev){
        int currFrame = (int)sprite.Get("frame");
        if (nextNotPrev) {
            if ((byte)currFrame < maxFrames) {
                sprite.Set("frame", currFrame + 1);
            }
        } else {
            if ((byte)currFrame > 0 ) {
                sprite.Set("frame", currFrame - 1);
            }
        }
        GD.Print(sprite.Get("frame"));
    }
    
    public void setFrame(byte frame){
//        if (frame < maxFrames && frame > 0) {
            sprite.Set("frame", frame);
 //       }
        GD.Print(sprite.Get("frame"));
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        sprite = this.GetNode("Sprite");
        maxFrames = (byte)((int)sprite.Get("vframes") * (int)sprite.Get("hframes") - 1);
        GD.Print(maxFrames);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}