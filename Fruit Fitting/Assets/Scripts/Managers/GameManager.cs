using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string GAME_SCENE = "Game";
    private const string MENU_SCENE = "Menu";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        EventManager.GameStartedEvent += GameStarted;
        EventManager.GameFinishedEvent += GameFinished;
    }

    private void OnDisable()
    {
        EventManager.GameStartedEvent -= GameStarted;
        EventManager.GameFinishedEvent -= GameFinished;
    }

    private void GameStarted()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    private void GameFinished()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
}
