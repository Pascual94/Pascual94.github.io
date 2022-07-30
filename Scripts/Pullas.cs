using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pullas : MonoBehaviour
{
    [SerializeField] GameObject controllerOfWorlds;
    [SerializeField] GameObject healthbar;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthbar.SendMessage("TakeDamage", 20f);
            //controllerOfWorlds.SendMessage("NewGame");
        }
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}
