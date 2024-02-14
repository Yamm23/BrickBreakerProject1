using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChooser : MonoBehaviour
{
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
