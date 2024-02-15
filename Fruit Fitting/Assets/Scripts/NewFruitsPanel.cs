using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewFruitsPanel : MonoBehaviour
{
    [SerializeField] private Button newFruitButtonPrefab;

    private List<NewFruitGO> newfruitsGOs = new List<NewFruitGO>();

    public NewFruitGO AddNewFruitGO()
    {
        Button newFruitButton = Instantiate(newFruitButtonPrefab, transform);
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

    public bool CheckAnyFruitRemain()
    {
        foreach (NewFruitGO newFruitGO in newfruitsGOs)
        {
            if (newFruitGO.image.enabled)
            {
                return true;
            }
        }

        return false;
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
