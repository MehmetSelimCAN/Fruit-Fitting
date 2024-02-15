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
    private string restrictionStr;

    private string wrongSpriteString = "<sprite name=\"Wrong\"> ";
    private string correctSpriteString = "<sprite name=\"Correct\"> ";

    public void SetText(string text)
    {
        restrictionStr = text;
        restrictionText.SetText(wrongSpriteString + restrictionStr);
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

    public void UpdateArea(bool isRestrictionPassed)
    {
        UpdateText(isRestrictionPassed);
        UpdateBackground(isRestrictionPassed);
    }

    private void UpdateText(bool isRestrictionPassed)
    {
        string correctnessSpriteString = isRestrictionPassed ? correctSpriteString : wrongSpriteString;
        restrictionText.SetText(correctnessSpriteString + restrictionStr);
    }

    private void UpdateBackground(bool isRestrictionPassed)
    {
        restrictionBackground.sprite = SpriteProvider.Instance.GetBackgroundSpriteForCorrectness(isRestrictionPassed);
        if (isRestrictionPassed)
        {
            ShrinkArea();
        }
    }
}

