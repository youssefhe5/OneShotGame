using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{

    public static void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel++);
        }

        if (currentLevel > PlayerPrefs.GetInt("levelsUnlocked"))
        {
            Debug.Log("Level " + PlayerPrefs.GetInt("levelsUnlocked") + " unlocked!");
        }

        
    }

}
