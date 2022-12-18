using Godot;
using System;
using System.Collections.Generic;

public class MainBody : Node
{

    private Label debugLabel, dbNameLabel;
    private Container DBNameContainer;
    private HBoxContainer MainColumnContainer, RowButtonHContainer;

    private ColumnType ColButtonVContainer, FirstVBoxContainer, SecondVBoxContainer;

    private Button BtnAddCol, BtnRemoveCol, BtnAddRow, BtnRemoveRow;

    private List<ColumnType> ColumnList;

    private PackedScene cellPS = GD.Load<PackedScene>("res://Scenes/Cell.tscn");


    public void debugLabelInputer(String s){
        debugLabel.Text = s;
    }

    private void addGeneralCol(){
        debugLabelInputer("Added New Column");

        ColumnType Column = new ColumnType();

        Column.Name = "Column" + ColumnList.Count;

        ColumnList.Add(Column);

        int ColCellListSize = MainColumnContainer.GetChild(0).GetChildren().Count - 1;

        for (int i = 0; i < ColCellListSize; i++){

            CellType Cell = (CellType) cellPS.Instance();
            Cell.RectSize = new Vector2(Column.RectSize.x,Column.RectSize.y);
            
            Column.AddChild(Cell);
            Column.addCell(Cell);

        }
        
        GD.Print(MainColumnContainer.GetChildren());
        GD.Print(ColumnList.Count);

        MainColumnContainer.AddChild(Column);
        MainColumnContainer.MoveChild(ColButtonVContainer, ColumnList.Count);
        
    }

    private void removeGeneralCol(){

        int size = MainColumnContainer.GetChildren().Count;
        GD.Print(size);

        ColumnType targetColumn = (ColumnType)MainColumnContainer.GetChild(size-2);

        if (size >= 4){

            
            debugLabelInputer("Removed column" + targetColumn.Name.ToString());

            ColumnList.Remove(targetColumn);
            MainColumnContainer.GetChild(size-2).QueueFree();
        }

    }

    private void addGeneralRow(){
        
        
        debugLabelInputer("Added New Row");

        int columnIndex = 1;

        foreach (ColumnType Column in ColumnList){
            CellType cell = (CellType) cellPS.Instance();
            cell.RectSize = new Vector2(Column.RectSize.x, 40);

            cell.Name = "Cell" + columnIndex.ToString();
            columnIndex++;
            
            Column.AddChild(cell);
            Column.addCell(cell);

            Column.MoveChild(RowButtonHContainer, Column.CellListSize());
        }


        
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

        RowButtonHContainer = GetNode<HBoxContainer>("MainColumnContainer/FirstVBoxContainer/RowButtonHContainer");


        
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
