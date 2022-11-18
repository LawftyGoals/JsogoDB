using Godot;
using System;
using System.Collections.Generic;

public class MainBody : Node
{

    private Label debugLabel, dbNameLabel;
    private Container DBNameContainer;
    private HBoxContainer MainColumnContainer;

    private VBoxContainer RowButtonVContainer;

    private Button BtnAddRow, BtnRemoveRow;


    private void debugLabelInputer(String s){
        debugLabel.Text = s;
    }

    private void addGeneralRow(){
        debugLabelInputer("Added New Row");

        VBoxContainer vBox = new VBoxContainer();
        
        Godot.Collections.Array listSizer = MainColumnContainer.GetChildren();

        vBox.Name = "vBox" + listSizer.Count;
        
        Panel pant = new Panel();
        pant.RectMinSize = new Vector2(20,20);

        vBox.AddChild(pant);

        MainColumnContainer.AddChild(vBox);
        MainColumnContainer.MoveChild(RowButtonVContainer, listSizer.Count);
        
    }

    private void removeGeneralRow(){

        Godot.Collections.Array listSizer = MainColumnContainer.GetChildren();
        int size = listSizer.Count;
        if (size >= 3){
            debugLabelInputer("Removed row " + MainColumnContainer.GetChild(size-2).Name.ToString());
        }
        MainColumnContainer.GetChild(size-2).QueueFree();

    }
    

    public override void _Ready()
    {
        debugLabel = GetNode<Label>("DBNameContainer/DebugLabel");
        debugLabel.Text = "Started";

        dbNameLabel = GetNode<Label>("DBNameContainer/DBNameLabel");
        dbNameLabel.Text = "Title not set.";

        DBNameContainer = GetNode<Container>("DBNameContainer");
        DBNameContainer.RectPosition = new Vector2(GetViewport().Size.x/2 - (dbNameLabel.RectSize.x/2), DBNameContainer.RectPosition.y);

        MainColumnContainer = GetNode<HBoxContainer>("MainColumnContainer");
        RowButtonVContainer = GetNode<VBoxContainer>("MainColumnContainer/RowButtonVContainer");

        BtnAddRow = GetNode<Button>("MainColumnContainer/RowButtonVContainer/BtnAddRow");
        BtnRemoveRow = GetNode<Button>("MainColumnContainer/RowButtonVContainer/BtnRemoveRow");

        BtnAddRow.Connect("pressed", this, nameof(addGeneralRow));
        BtnRemoveRow.Connect("pressed", this, nameof(removeGeneralRow));


        
        
        
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
