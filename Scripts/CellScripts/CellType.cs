using Godot;
using System;

public class CellType : Panel
{
    
    private TextEdit textEdit;
    private MainBody MainBodyPanel;

    private void updateCellValue(){
        updateDebugLabel();
        setColorByContent();
    }
    private void updateDebugLabel(){
        MainBodyPanel.debugLabelInputer(String.Format("Cell '{0}' value changed", this.Name));
        GD.Print("updateddebuglabel");
    }


    private void setColorByContent(){
        if (textEdit.Text.GetType() == typeof(int)){
            textEdit.AddColorOverride("default_color", new Color(1,0,1,1));
        } else {
            textEdit.AddColorOverride("default_color", new Color(1,1,1,1));
        }
    }
    public override void _Ready(){

        MainBodyPanel = GetNode<MainBody>("/root/Background/MainBodyPanel");
        textEdit = GetNode<TextEdit>("TextEdit");

        textEdit.RectMinSize = new Vector2(this.RectSize.x-5, this.RectSize.y-5);
        textEdit.RectSize = new Vector2(this.RectSize.x-5, this.RectSize.y-5);

        textEdit.Connect("focus_exited", this, "updateCellValue");

    }


  // Called every frame. 'delta' is the elapsed time since the previous frame.
  //public override void _Process(float delta)
  //{
  //    //if (!this.HasFocus()){
  //      //    setColorByContent();
  //      //}
  //}


}
