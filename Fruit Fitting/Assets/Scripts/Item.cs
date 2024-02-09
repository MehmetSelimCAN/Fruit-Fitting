using UnityEngine;

public class Item : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;

    private ItemType itemType;
    public ItemType ItemType { get { return itemType; } }

    public void PrepareItem(ItemType itemType)
    {
        this.itemType = itemType;
        PrepareSprite();
    }

    public void ChangeItemType(ItemType itemType)
    {
        this.itemType = itemType;

        UpdateSprite();
    }

    public void PrepareSprite()
    {
        Sprite sprite = GetSpritesForItemType();
        SpriteRenderer = AddSprite(sprite);
    }

    public Sprite GetSpritesForItemType()
    {
        SpriteProvider spriteProvider = SpriteProvider.Instance;

        switch (itemType)
        {
            case ItemType.Apple:
                return spriteProvider.AppleSprite;
            case ItemType.Banana:
                return spriteProvider.BananaSprite;
            case ItemType.Blueberry:
                return spriteProvider.BlueberrySprite;
            case ItemType.Pear:
                return spriteProvider.PearSprite;
        }

        return null;
    }

    public SpriteRenderer AddSprite(Sprite sprite)
    {
        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        return spriteRenderer;
    }

    public void UpdateSprite()
    {
        Sprite sprite = GetSpritesForItemType();
        SpriteRenderer.sprite = sprite;
    }
}
