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

    [SerializeField] private SpriteRenderer GridBorderPrefab;

    private void OnDisable()
    {
        EventManager.CellSwapEvent -= SwapCells;
    }

    private void OnEnable()
    {
        EventManager.CellSwapEvent += SwapCells;
    }

    public void Prepare(LevelDataSO currentLevelData)
    {
        Rows = currentLevelData.Rows;
        Cols = currentLevelData.Cols;
        CellsBackground = new CellBackground[Cols, Rows];
        Cells = new Cell[Cols, Rows];

        CreateCellsBackground();
        PrepareCellsBackground();

        CreateCells();
        PrepareCells();

        AdjustGridPosition();
        AdjustGridBorder();
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

    private void AdjustGridPosition()
    {
        Vector2 centerOfLeftSide = new Vector2(Screen.width / 4, Screen.height / 2);
        Vector3 centerOfLeftSideToWorldPoint = Camera.main.ScreenToWorldPoint(centerOfLeftSide);
        centerOfLeftSideToWorldPoint = new Vector3(centerOfLeftSideToWorldPoint.x, centerOfLeftSideToWorldPoint.y, 0);

        float widthOffset = ((Cols - 1) / 2f);
        float heightOffset = ((Rows - 1) / 2f);

        CellsParent.position = centerOfLeftSideToWorldPoint - new Vector3(widthOffset, heightOffset);
        CellsBackgroundParent.position = centerOfLeftSideToWorldPoint - new Vector3(widthOffset, heightOffset);
    }

    private void AdjustGridBorder()
    {
        float sizeOffset = 0.25f;

        float widthOffset = ((Cols - 1) / 2f);
        float heightOffset = ((Rows - 1) / 2f);

        var gridBorder = Instantiate(GridBorderPrefab, Vector3.zero, Quaternion.identity, transform);

        gridBorder.size = new Vector2(Cols + sizeOffset, Rows + sizeOffset);
        gridBorder.transform.position = CellsParent.position + new Vector3(widthOffset, heightOffset);
    }

    public Cell GetEmptyCell()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {
                if (Cells[x, y].Item == null)
                {
                    return Cells[x, y];
                }
            }
        }

        return null;
    }
         
    public void SwapCells(Cell firstCell, Cell secondCell)
    {
        Cells[firstCell.X, firstCell.Y] = secondCell;
        Cells[secondCell.X, secondCell.Y] = firstCell;

        Vector3Int tempPosition = firstCell.Position;
        firstCell.Move(secondCell.Position);
        secondCell.Move(tempPosition);

        EventManager.CellMoved();
    }
}
