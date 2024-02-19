using UnityEngine;

public static class PlayerPrefsManager
{
    public static int GetLastLevelNumber()
    {
        SetLastLevelNumber(2);
        if (PlayerPrefs.HasKey("LevelNumber"))
        {
            return PlayerPrefs.GetInt("LevelNumber", 1);
        }
        else
        {
            PlayerPrefs.SetInt("LevelNumber", 1);
            return PlayerPrefs.GetInt("LevelNumber");
        }
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
