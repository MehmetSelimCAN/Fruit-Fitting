using UnityEngine;

public class CellDragDrop : MonoBehaviour
{
    private BoxCollider2D cellCollider;
    private Transform draggingCellTransform;
    private Cell cell;
    public Cell Cell { get { return cell; } set { cell = value; } }

    private Vector3Int firstPosition;

    private SpriteRenderer cellSpriteRenderer;
    private const int DRAGGING_CELL_SORTING_ORDER = 1;
    private const int CELL_SORTING_ORDER = 0;

    private void Awake()
    {
        draggingCellTransform = transform;
        cellCollider = GetComponent<BoxCollider2D>();
        cellSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        GetCellFirstPosition();
        DisableCellCollider();
        ChangeCellSpriteRendererSortOrder(DRAGGING_CELL_SORTING_ORDER);
    }

    private void OnMouseDrag()
    {
        DragCell();
    }

    private void OnMouseUp()
    {
        SwapCell();
    }

    private void GetCellFirstPosition()
    {
        firstPosition = cell.Position;
    }

    private void DisableCellCollider()
    {
        cellCollider.enabled = false;
    }

    private void EnableCellCollider()
    {
        cellCollider.enabled = true;
    }

    private void ChangeCellSpriteRendererSortOrder(int newSortingOrder)
    {
        cellSpriteRenderer.sortingOrder = newSortingOrder;
    }

    private void DragCell()
    {
        Vector2 newPosition = GetMousePosition() - transform.position;
        draggingCellTransform.Translate(newPosition);
    }

    private void SwapCell()
    {
        Cell draggingCell = cell;

        Cell cellToSwap = GetCellToSwap();

        EnableCellCollider();
        ChangeCellSpriteRendererSortOrder(CELL_SORTING_ORDER);

        if (cellToSwap == null)
        {
            ResetCellPosition();
        }
        else
        {
            EventManager.SwapCell(draggingCell, cellToSwap);
        }
    }

    private void ResetCellPosition()
    {
        draggingCellTransform.localPosition = firstPosition;
    }

    private Cell GetCellToSwap()
    {
        Vector2 mousePosition = GetMousePosition();
        var cellHit = Physics2D.OverlapPoint(mousePosition) as BoxCollider2D;
        return cellHit?.gameObject.GetComponent<Cell>();
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
}
