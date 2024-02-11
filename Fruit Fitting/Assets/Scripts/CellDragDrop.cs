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
        firstPosition = cell.Position;
        cellCollider.enabled = false;
        cellSpriteRenderer.sortingOrder = DRAGGING_CELL_SORTING_ORDER;
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = GetMousePosition() - transform.position;
        draggingCellTransform.Translate(newPosition);
    }

    private void OnMouseUp()
    {
        Cell draggingCell = cell;

        Vector2 mousePosition = GetMousePosition();
        var cellHit = Physics2D.OverlapPoint(mousePosition) as BoxCollider2D;
        Cell cellToSwap = cellHit?.gameObject.GetComponent<Cell>();

        cellCollider.enabled = true;
        cellSpriteRenderer.sortingOrder = CELL_SORTING_ORDER;

        if (cellToSwap == null)
        {
            draggingCellTransform.localPosition = firstPosition;
        }
        else
        {
            EventManager.SwapCell(draggingCell, cellToSwap);
        }
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
}
