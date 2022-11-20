using Godot;
using System;
using System.Collections.Generic;

public class ColumnType : VBoxContainer
{
    private List<CellType> CellList = new List<CellType>();

    public int CellListSize(){
        return CellList.Count;
    }

    public void addCell(CellType cell){
        CellList.Add(cell);
    }

    public override void _Ready()
    {
        GD.Print(this.GetType());
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
