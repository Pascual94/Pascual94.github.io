using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerOfWorlds : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("NEWGAME");
        Time.timeScale = 1f;
    }
    public void World2()
    {
        SceneManager.LoadScene("WORLD2");
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void World3()
    {
        SceneManager.LoadScene("WORLD3");
        Time.timeScale = 1f;
    }
}
