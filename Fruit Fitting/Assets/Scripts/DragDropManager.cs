using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    public static DragDropManager Instance { get; private set; }
    public Grid grid;

    private void Awake()
    {
        Instance = this;
    }

    public void TryToSwap(Vector2 firstPosition, Cell firstCell, Cell secondCell)
    {
        if (secondCell == null)
        {
            firstCell.transform.position = firstPosition;
            return;
        }

        grid.SwapCells(firstCell, secondCell);
    }
}
