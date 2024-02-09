using System.Collections;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [HideInInspector] public int X;
    [HideInInspector] public int Y;
    [HideInInspector] public Vector3Int Position { get { return new Vector3Int(X, Y, 0); } }

    private Item item;
    public Item Item { get { return item; } }

    private float swipeAnimationSpeed = 12.5f;

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

    public void Move(Vector3Int newPosition)
    {
        StartCoroutine(MoveAnimation(newPosition));

        X = newPosition.x;
        Y = newPosition.y;
    }

    private IEnumerator MoveAnimation(Vector3Int newPosition)
    {
        while (Vector3.Distance(transform.localPosition, newPosition) > Mathf.Epsilon)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPosition, Time.deltaTime * swipeAnimationSpeed);
            yield return null;
        }

        transform.localPosition = newPosition;
        UpdateLabel();
    }
}
