using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{
    public Button[] buttons;
    //This is for the LevelUnlock
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i = 0; i < buttons.Length; i++) 
        {
            buttons[i].interactable = false;
        }
        for(int i = 0;i<unlockedLevel; i++)
        { 
            buttons[i].interactable = true;
        }
    }
    //This is for the LevelChoosing in Easy Scene
    public void EasyLevelOpen(int levelId)
    {
        string levelName = "ELevel " + levelId;
        SceneManager.LoadScene(levelName);

    }
    //This is for the three scene in Difficulties.
    public void BackArrow()
    {
        SceneManager.LoadScene("World");
    }
    public void EasyScene()
    {
        SceneManager.LoadScene("Easy");
    }
}
