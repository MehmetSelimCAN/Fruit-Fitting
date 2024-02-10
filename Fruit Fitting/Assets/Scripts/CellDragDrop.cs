using UnityEngine;

public class CellDragDrop : MonoBehaviour
{
    private BoxCollider2D cellCollider;
    private Transform cellTransform;
    private Cell cell;
    public Cell Cell { get { return cell; } set { cell = value; } }

    private Vector2 firstPosition;

    private void Awake()
    {
        cellTransform = transform;
        cellCollider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        firstPosition = new Vector2(cell.X, cell.Y);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = GetMousePosition() - transform.position;
        cellTransform.Translate(newPosition);
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

        DragDropManager.Instance.TryToSwap(firstPosition, draggingCell, cellToSwap);

        cellCollider.enabled = true;
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
}
