using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool active;
    [SerializeField] GameObject gamePaused;
    [SerializeField] GameObject gameResetter;

    void Awake()
    {
        gamePaused.SetActive(active);
        gameResetter.SetActive(active);
    }
    void Update()
    {
        if (Input.GetButtonDown("Paused"))
        {
            GamePaused();
            
        }
        if (Input.GetButtonDown("Restart"))
        {
            active = !active;
            gameResetter.SetActive(active);
            Time.timeScale = (active) ? 0 : 1f;
        }

    }
    public void GamePaused()
    {
        active = !active;
        gamePaused.SetActive(active);
        Time.timeScale = (active) ? 0 : 1f;
    }
}
