using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button levelButton;
    [SerializeField] private TextMeshProUGUI levelText;

    private void UpdateLevelText()
    {
        int lastLevelNumber = PlayerPrefsManager.GetLastLevelNumber();
        levelText.SetText("Level " + lastLevelNumber);
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
