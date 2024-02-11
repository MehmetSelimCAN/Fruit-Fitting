using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Grid Grid;

    public void PrepareGame()
    {
        PrepareGrid();
    }

    private void PrepareGrid()
    {
        Grid.Rows = 5;
        Grid.Cols = 5;
        Grid.CellsBackground = new CellBackground[Grid.Cols, Grid.Rows];
        Grid.Cells = new Cell[Grid.Cols, Grid.Rows];
        Grid.Prepare();
    }

    public void AddApple()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Apple);
    }

    public void AddBanana()
    {
        Cell emptyCell = Grid.GetEmptyCell();
        emptyCell.InsertItem(ItemType.Banana);
    }
}
