using UnityEngine;

public class SpriteProvider : MonoBehaviour
{
    public static SpriteProvider Instance { get; private set; }

    public Sprite AppleSprite;
    public Sprite BananaSprite;
    public Sprite CarrotSprite;
    public Sprite CherrySprite;
    public Sprite CoconutSprite;
    public Sprite EggplantSprite;
    public Sprite GrapesSprite;
    public Sprite LemonSprite;
    public Sprite LettuceSprite;
    public Sprite MushroomSprite;
    public Sprite OrangeSprite;
    public Sprite PearSprite;

    public Sprite correctBackgroundSprite;
    public Sprite wrongBackgroundSprite;

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
            case ItemType.Carrot:
                return CarrotSprite;
            case ItemType.Cherry:
                return CherrySprite;
            case ItemType.Coconut:
                return CoconutSprite;
            case ItemType.Eggplant:
                return EggplantSprite;
            case ItemType.Grapes:
                return GrapesSprite;
            case ItemType.Lemon:
                return LemonSprite;
            case ItemType.Lettuce:
                return LettuceSprite;
            case ItemType.Mushroom: 
                return MushroomSprite;
            case ItemType.Orange:
                return OrangeSprite;
            case ItemType.Pear:
                return PearSprite;
        }
        return null;
    }

    public Sprite GetBackgroundSpriteForCorrectness(bool isCorrect)
    {
        if (isCorrect)
        {
            return correctBackgroundSprite;
        }

        return wrongBackgroundSprite;
    }
}
