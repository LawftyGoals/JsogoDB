using Godot;
using System;


public class TextEditBehavior : TextEdit
{
    
    public override void _Ready()
    {
        
    }

    private void setColorByContent(){
        if (this.Text.GetType() == typeof(int)){
            this.AddColorOverride("default_color", new Color(1,0,1,0));
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (!this.HasFocus()){
            
        }

    }
}
