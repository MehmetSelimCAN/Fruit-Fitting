using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestrictionArea : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private NewFruitsPanel newFruitsPanel;
    public NewFruitsPanel NewFruitsPanel { get { return newFruitsPanel; } }

    [SerializeField] private Image restrictionBackground;
    [SerializeField] private TextMeshProUGUI restrictionText;

    private Color32 correctColor = new Color32(0x07, 0x8E, 0x19, 0xFF);
    private Color32 wrongColor = new Color32(0xBE, 0x23, 0x23, 0xFF);

    public void SetText(string text)
    {
        restrictionText.SetText(text);
    }

    public void UpdateBackground(bool isRestrictionPassed)
    {
        restrictionBackground.color = isRestrictionPassed ? correctColor : wrongColor;
        if (isRestrictionPassed)
        {
            ShrinkArea();
        }
    }

    public void EnlargeArea()
    {
        rectTransform.sizeDelta = new Vector2(460, 100);
        EventManager.RestrictionAreaUpdated();
    }

    public void ShrinkArea()
    {
        rectTransform.sizeDelta = new Vector2(460, 50);
        EventManager.RestrictionAreaUpdated();
    }
}

