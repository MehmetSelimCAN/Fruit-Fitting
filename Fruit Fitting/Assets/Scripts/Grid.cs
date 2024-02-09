using UnityEngine;

public class Grid : MonoBehaviour
{
    public static int Rows;
    public static int Cols;

    public Transform CellsParent;
    [SerializeField] private Cell cellPrefab;
    public static Cell[,] Cells;

    public Transform CellsBackgroundParent;
    [SerializeField] private CellBackground cellBackgroundPrefab;
    public static CellBackground[,] CellsBackground;

    private void Awake()
    {
        Prepare();
    }

    public void Prepare()
    {
        CreateCellsBackground();
        PrepareCellsBackground();

        CreateCells();
        PrepareCells();
    }

    private void CreateCellsBackground()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {
                var cellBackground = Instantiate(cellBackgroundPrefab, Vector3.zero, Quaternion.identity, CellsBackgroundParent);
                CellsBackground[x, y] = cellBackground;
            }
        }
    }

    private void PrepareCellsBackground()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {
                CellsBackground[x, y].Prepare(x, y);
            }
        }
    }

    private void CreateCells()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {
                var cell = Instantiate(cellPrefab, Vector3.zero, Quaternion.identity, CellsParent);
                Cells[x, y] = cell;
            }
        }
    }

    private void PrepareCells()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {
                Cells[x, y].Prepare(x, y);
            }
        }
    }

    private void SwapCells(Cell firstCell, Cell secondCell)
    {
        Cells[firstCell.X, firstCell.Y] = secondCell;
        Cells[secondCell.X, secondCell.Y] = firstCell;

        Vector3Int tempPosition = firstCell.Position;
        firstCell.Move(secondCell.Position);
        secondCell.Move(tempPosition);
    }
}
