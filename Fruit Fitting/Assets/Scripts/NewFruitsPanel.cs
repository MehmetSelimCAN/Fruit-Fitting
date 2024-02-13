using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewFruitsPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newFruitsText;
    [SerializeField] private Transform newFruitsHorizontalLayout;
    [SerializeField] private Button newFruitButtonPrefab;

    private List<NewFruitGO> newfruitsGOs = new List<NewFruitGO>();

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetText(string text)
    {
        newFruitsText.SetText(text);
    }

    public NewFruitGO AddNewFruitGO()
    {
        Button newFruitButton = Instantiate(newFruitButtonPrefab, newFruitsHorizontalLayout);
        Image newFruitImage = newFruitButton.GetComponent<Image>();
        NewFruitGO newFruitGO = new NewFruitGO(newFruitButton, newFruitImage);

        newfruitsGOs.Add(newFruitGO);
        return newFruitGO;
    }

    public void ChangeButtonImage(NewFruitGO newFruitGO, ItemType itemType)
    {
        newFruitGO.image.sprite = SpriteProvider.Instance.GetSpriteForItemType(itemType);
    }

    public void DisableButtonImage(NewFruitGO newFruitGO)
    {
        newFruitGO.image.enabled = false;
    }

    public void CheckAnyFruitRemain()
    {
        foreach (NewFruitGO newFruitGO in newfruitsGOs)
        {
            if (newFruitGO.image.enabled)
            {
                return;
            }
        }

        //If no fruit remain, clear ui
        ClearNewFruitGOList();
        ClearHorizontalLayout();
        Hide();
    }

    private void ClearNewFruitGOList()
    {
        newfruitsGOs.Clear();
    }

    private void ClearHorizontalLayout()
    {
        foreach (Transform child in newFruitsHorizontalLayout)
        {
            Destroy(child.gameObject);
        }
    }
}

[Serializable]
public class NewFruitGO
{
    public Button button;
    public Image image;

    public NewFruitGO(Button _button, Image _image)
    {
        button = _button;
        image = _image;
    }
}
