using Godot;
using System;
using System.Collections.Generic;

public class MainBody : Node
{

    private Label debugLabel, dbNameLabel;
    private Container DBNameContainer;
    private HBoxContainer MainColumnContainer;

    private ColumnType ColButtonVContainer, FirstVBoxContainer, SecondVBoxContainer;

    private Button BtnAddCol, BtnRemoveCol, BtnAddRow, BtnRemoveRow;

    private List<ColumnType> ColumnList;

    private PackedScene cellPS = GD.Load<PackedScene>("res://Cell.tscn");


    public void debugLabelInputer(String s){
        debugLabel.Text = s;
    }

    private void addGeneralCol(){
        debugLabelInputer("Added New Column");

        ColumnType Column = new ColumnType();

        Column.Name = "Column" + ColumnList.Count;

        int ColCellListSize = ColumnList[0].GetChildren().Count;

        for (int i = 0; i < ColCellListSize; i++){
            
            CellType Cell = new CellType();
            Cell.RectSize = new Vector2(Column.RectSize.x,Column.RectSize.y);
            
            Column.AddChild(Cell);

        }
        
        MainColumnContainer.AddChild(Column);
        MainColumnContainer.MoveChild(ColButtonVContainer, ColumnList.Count);
        
    }

    private void removeGeneralCol(){

        int size = ColumnList.Count;
        if (size >= 2){
            debugLabelInputer("Removed column" + MainColumnContainer.GetChild(size-2).Name.ToString());
        }
        MainColumnContainer.GetChild(size-2).QueueFree();

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
        MainColumnContainer.MoveChild(ColButtonVContainer, listSizer.Count);
        
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

        var test = cellPS.Instance().GetChildren();

        foreach (var x in test){
            GD.Print(x.GetType());
        }

        ColumnList = new List<ColumnType>();

        debugLabel = GetNode<Label>("DBNameContainer/DebugLabel");
        debugLabel.Text = "Started";

        dbNameLabel = GetNode<Label>("DBNameContainer/DBNameLabel");
        dbNameLabel.Text = "Title not set.";

        DBNameContainer = GetNode<Container>("DBNameContainer");
        DBNameContainer.RectPosition = new Vector2(GetViewport().Size.x/2 - (dbNameLabel.RectSize.x/2), DBNameContainer.RectPosition.y);

        MainColumnContainer = GetNode<HBoxContainer>("MainColumnContainer");

        ColButtonVContainer = GetNode<ColumnType>("MainColumnContainer/ColButtonVContainer");
        ColumnList.Add(ColButtonVContainer);
        FirstVBoxContainer = GetNode<ColumnType>("MainColumnContainer/FirstVBoxContainer");
        ColumnList.Add(FirstVBoxContainer);
        SecondVBoxContainer = GetNode<ColumnType>("MainColumnContainer/SecondVBoxContainer");
        ColumnList.Add(SecondVBoxContainer);
        
        BtnAddCol = GetNode<Button>("MainColumnContainer/ColButtonVContainer/BtnAddCol");
        BtnRemoveCol = GetNode<Button>("MainColumnContainer/ColButtonVContainer/BtnRemoveCol");
        BtnAddRow = GetNode<Button>("MainColumnContainer/FirstVBoxContainer/HBoxContainer/BtnAddRow");
        BtnRemoveRow = GetNode<Button>("MainColumnContainer/FirstVBoxContainer/HBoxContainer/BtnRemoveRow");

        BtnAddCol.Connect("pressed", this, nameof(addGeneralCol));
        BtnRemoveCol.Connect("pressed", this, nameof(removeGeneralCol));
        BtnAddRow.Connect("pressed", this, nameof(addGeneralRow));
        BtnRemoveRow.Connect("pressed", this, nameof(removeGeneralRow));

    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
