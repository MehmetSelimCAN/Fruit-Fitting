using UnityEngine;

public class CellBackground : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    [SerializeField] private Sprite lightGridTile;
    [SerializeField] private Sprite darkGridTile;

    public void Prepare(int x, int y)
    {
        transform.localPosition = new Vector3(x, y);
        PrepareSprite(x, y);
    }

    public void PrepareSprite(int x, int y)
    {
        Sprite sprite = GetSpriteForCellPosition(x, y);
        SpriteRenderer = AddSprite(sprite);
    }

    public Sprite GetSpriteForCellPosition(int x, int y)
    {
        return (x + y) % 2 == 0 ? lightGridTile : darkGridTile;
    }

    public SpriteRenderer AddSprite(Sprite sprite)
    {
        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        return spriteRenderer;
    }
}
