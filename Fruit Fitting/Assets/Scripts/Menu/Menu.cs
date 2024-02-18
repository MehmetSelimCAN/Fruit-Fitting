using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button levelButton;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private Transform menuScene;
    [SerializeField] private Transform gameScene;

    private void Awake()
    {
        levelButton.onClick.AddListener(() => LevelButtonClicked());
        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        int lastLevelNumber = PlayerPrefsManager.GetLastLevelNumber();
        levelText.SetText("Level " + lastLevelNumber);
    }

    private void LevelButtonClicked()
    {
        PrepareGameScene();
        levelManager.PrepareGame();
    }

    private void PrepareGameScene()
    {
        menuScene.gameObject.SetActive(false);
        gameScene.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        UpdateLevelText();
    }
}
