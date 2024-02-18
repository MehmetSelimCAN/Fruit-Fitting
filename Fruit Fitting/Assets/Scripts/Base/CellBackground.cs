using UnityEngine;

public class CellBackground : MonoBehaviour
{
    [SerializeField] private Sprite lightGridTile;
    [SerializeField] private Sprite darkGridTile;
    private const int BACKGROUND_SORTING_ORDER = -5;

    public void Prepare(int x, int y)
    {
        transform.localPosition = new Vector3(x, y);
        PrepareSprite(x, y);
    }

    public void PrepareSprite(int x, int y)
    {
        Sprite sprite = GetSpriteForCellPosition(x, y);
        AddSprite(sprite);
    }

    public Sprite GetSpriteForCellPosition(int x, int y)
    {
        return (x + y) % 2 == 0 ? lightGridTile : darkGridTile;
    }

    public SpriteRenderer AddSprite(Sprite sprite)
    {
        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = BACKGROUND_SORTING_ORDER;
        spriteRenderer.sprite = sprite;

        return spriteRenderer;
    }
}
