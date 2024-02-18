using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemType itemType;
    public ItemType ItemType { get { return itemType; } }

    public void PrepareItem(ItemType itemType)
    {
        this.itemType = itemType;
        PrepareSprite();
    }

    public void PrepareSprite()
    {
        Sprite sprite = SpriteProvider.Instance.GetSpriteForItemType(itemType);
        AddSprite(sprite);
    }

    public SpriteRenderer AddSprite(Sprite sprite)
    {
        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        return spriteRenderer;
    }
}
