using UnityEngine;

public class SpriteProvider : MonoBehaviour
{
    public static SpriteProvider Instance { get; private set; }

    public Sprite AppleSprite;
    public Sprite BananaSprite;
    public Sprite BlueberrySprite;
    public Sprite PearSprite;

    private void Awake()
    {
        Instance = this;
    }
}
