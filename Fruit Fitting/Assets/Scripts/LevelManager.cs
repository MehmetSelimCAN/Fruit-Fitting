using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Grid Grid;

    public void PrepareGrid()
    {
        Grid.Rows = 8;
        Grid.Cols = 8;
        Grid.CellsBackground = new CellBackground[Grid.Rows, Grid.Cols];
        Grid.Cells = new Cell[Grid.Rows, Grid.Cols];
        Grid.Prepare();
    }

    public void AddApple()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Apple);
    }
}
