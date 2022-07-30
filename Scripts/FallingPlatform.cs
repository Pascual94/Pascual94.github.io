using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Vector3         start;
    float           respawDelay = 5f;
    float           fallDelay   = 1f;
    Rigidbody2D     rb2d;
    BoxCollider2D   boxCol2d;

    void Start()
    {
        start       = transform.position;
        rb2d        = GetComponent<Rigidbody2D>();
        boxCol2d    = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallDelay);
            Invoke("Respawn", fallDelay + respawDelay);
        }
    }

    void Falling()
    {
        rb2d.isKinematic    = false;
        boxCol2d.isTrigger  = true;

    }

    void Respawn()
    {
        transform.position  = start;
        rb2d.isKinematic    = true;
        rb2d.velocity = Vector3.zero;
        boxCol2d.isTrigger  = false;
    }
}
