using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button levelButton;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private LevelDataListSO levelDatas;

    private void UpdateLevelText()
    {
        int lastLevelNumber = PlayerPrefsManager.GetLastLevelNumber();
        if (lastLevelNumber > levelDatas.list.Count)
        {
            levelText.SetText("Congratulations! You finished the game.");
            levelButton.interactable = false;
        }
        else
        {
            levelText.SetText("Level " + lastLevelNumber);
        }
    }

    private void LevelButtonClicked()
    {
        EventManager.GameStarted();
    }

    private void OnEnable()
    {
        UpdateLevelText();
        levelButton.onClick.AddListener(() => LevelButtonClicked());
    }

    private void OnDisable()
    {
        levelButton.onClick.RemoveListener(() => LevelButtonClicked());
    }
}
