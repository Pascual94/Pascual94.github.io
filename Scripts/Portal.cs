using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject youWin;

    void Awake()
    {
        youWin.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            youWin.SetActive(true);
            Time.timeScale = 0;
        }
    }   
}
