using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    [SerializeField] GameObject objetoToAddForce;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AddForce();
            Debug.Log("Hemos disparado");
        }
    }

    public void AddForce()
    {
        GameObject clon = Instantiate(objetoToAddForce, transform.position,transform.rotation);
        Rigidbody2D rb2dClon = clon.GetComponent<Rigidbody2D>();
        rb2dClon.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}
