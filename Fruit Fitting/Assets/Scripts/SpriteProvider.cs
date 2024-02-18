using UnityEngine;

public class SpriteProvider : MonoBehaviour
{
    public static SpriteProvider Instance { get; private set; }

    public Sprite AppleSprite;
    public Sprite BananaSprite;
    public Sprite BlueberrySprite;
    public Sprite GrapesSprite;
    public Sprite OrangeSprite;
    public Sprite PearSprite;
    public Sprite StrawberrySprite;

    private void Awake()
    {
        Instance = this;
    }

    public Sprite GetSpriteForItemType(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Apple:
                return AppleSprite;
            case ItemType.Banana:
                return BananaSprite;
            case ItemType.Blueberry:
                return BlueberrySprite;
            case ItemType.Grapes:
                return GrapesSprite;
            case ItemType.Orange:
                return OrangeSprite;
            case ItemType.Pear:
                return PearSprite;
            case ItemType.Strawberry:
                return StrawberrySprite;
        }

        return null;
    }
}
