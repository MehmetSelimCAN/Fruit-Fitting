using UnityEngine;

public class Cell : MonoBehaviour
{
    [HideInInspector] public int X;
    [HideInInspector] public int Y;
    [HideInInspector] public Vector3Int Position { get { return new Vector3Int(X, Y, 0); } }

    private Item item;
    public Item Item { get { return item; } }

    public void Prepare(int x, int y)
    {
        X = x;
        Y = y;
        transform.localPosition = new Vector3(x, y);
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        var cellName = X + ":" + Y;
        gameObject.name = "Cell " + cellName;
    }

    public void InsertItem(ItemType itemType)
    {
        if (item != null) return;

        item = ItemFactory.CreateItem(this, itemType);
        AddDragDrop();
    }

    private void AddDragDrop()
    {
        CellDragDrop cellDragDrop = gameObject.AddComponent<CellDragDrop>();
        cellDragDrop.Cell = this;
    }

    public void Move(Vector3Int newPosition)
    {
        transform.localPosition = newPosition;
        X = newPosition.x;
        Y = newPosition.y;
    }
}
