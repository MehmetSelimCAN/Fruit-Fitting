using UnityEngine;

public class CellDragDrop : MonoBehaviour
{
    private BoxCollider2D cellCollider;
    private Transform draggingCellTransform;
    private Cell cell;
    public Cell Cell { get { return cell; } set { cell = value; } }

    private Vector3Int firstPosition;

    private void Awake()
    {
        draggingCellTransform = transform;
        cellCollider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        firstPosition = cell.Position;
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = GetMousePosition() - transform.position;
        draggingCellTransform.Translate(newPosition);
    }

    private void OnMouseUp()
    {
        cellCollider.enabled = false;

        Vector2 mousePosition = GetMousePosition();
        var cellHit = Physics2D.OverlapPoint(mousePosition) as BoxCollider2D;

        Cell draggingCell = cell;
        Cell cellToSwap = null;
        if (cellHit != null)
        {
            cellToSwap = cellHit.gameObject.GetComponent<Cell>();
        }

        if (cellToSwap == null)
        {
            draggingCellTransform.position = firstPosition;
        }
        else
        {
            EventManager.SwapCell(draggingCell, cellToSwap);
        }

        cellCollider.enabled = true;
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
}
