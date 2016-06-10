using UnityEngine;
using System.Collections;

public class PlayerPrefManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    //Volume handling
    public static void setMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range!");
        }
    }

    public static float getMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //Level handling
    public static void setUnlockLevel(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // 1 = unlocked
        }
        else
        {
            Debug.LogError("Trying to unlock a level who's screen number is not in build order!");
        }
    }

    public static bool isLevelUnlocked(int level)
    {
        if (!PlayerPrefs.HasKey(LEVEL_KEY + level.ToString()))
        {
            return false;
        }

        if (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Difficulty handling
    public static void setDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty parameter is out of range! It should go from 1f to 3f");
        }
    }

    public static float getDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
