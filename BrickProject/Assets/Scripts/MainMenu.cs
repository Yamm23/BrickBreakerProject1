using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //This is For the Main Menu Scene
    public void PlayGame()
    {
        SceneManager.LoadScene("World");
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }
    public void Quit()
    {
        Application.Quit();
    }


    //This is for the World Scene
    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Normal()
    {
        SceneManager.LoadScene("Normal");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }

    public void LeftArrow()
    {
        SceneManager.LoadScene("MainMenu");
    }




}
