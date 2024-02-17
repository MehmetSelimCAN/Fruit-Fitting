using UnityEngine;

public static class PlayerPrefsManager
{
    public static int GetLastLevelNumber()
    {
        return PlayerPrefs.GetInt("LevelNumber", 1);
    }

    public static void SetLastLevelNumber(int levelNumber)
    {
        PlayerPrefs.SetInt("LevelNumber", levelNumber);
    }

    public static void IncreaseLastLevelNumber()
    {
        PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
    }
}
