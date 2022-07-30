using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    /*Rigidbody2D     rb2d;
    Player          player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            //Aqui vamos anclar al personaje a la plataforma para que se mueve con ella y no haiga bug de pensar que esta cayendo
            player.transform.parent = col.transform;
            // Aqui estamos ejecutando la accion si todo es correcto
            player.grounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }
        if (col.gameObject.tag == "Platform")
        {
            // Aqui vamos anclar al personaje a la plataforma para que se mueve con ella y no haiga bug de pensar que esta cayendo
            player.transform.parent = col.transform;
            // Aqui estamos ejecutando la accion si todo es correcto
            player.grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }
        if (col.gameObject.tag == "Platform")
        {
            // Aqui vamos a desanclar al personaje de la plataforma para que no se mueve con ella y no haiga bug de pensar que esta cayendo
            player.transform.parent = null;
            // Aqui estamos ejecutando la accion si todo es correcto
            player.grounded = false;
        }
    }
    */
}
