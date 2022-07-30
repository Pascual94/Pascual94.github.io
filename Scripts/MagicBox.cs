using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBox : MonoBehaviour
{
    [SerializeField] GameObject   obj1,   obj2,   obj3;
    [SerializeField] GameObject   objc1Pref, objc2Pref, objc3Pref;

    public Transform cañon;

    bool activo;

    int x;
    void Start()
    {
        activo = true;
        StartCoroutine(ActivadordeObjetos());
    }
    IEnumerator ActivadordeObjetos()
    {
        while(activo)
        {
            obj1.SetActive(true);
            obj2.SetActive(false);
            obj3.SetActive(false);
            x = 1;
            yield return new WaitForSeconds(1);
            obj1.SetActive(false);
            obj2.SetActive(true);
            obj3.SetActive(false);
            x = 2;
            yield return new WaitForSeconds(1);
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(true);
            x = 3;
            yield return new WaitForSeconds(1);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cabeza")
        {
            if (x == 1)
            {
                StopCoroutine(ActivadordeObjetos());
                GameObject clon1 = Instantiate(objc1Pref, cañon.position, cañon.rotation);
                Rigidbody2D rb2dClon1 = clon1.GetComponent<Rigidbody2D>();              
                rb2dClon1.AddForce(Vector2.up * 5,ForceMode2D.Impulse);
                clon1.gameObject.name = "Coin1";
                Destroy(gameObject);
                

            }
            if (x == 2)
            {
                StopCoroutine(ActivadordeObjetos());
                GameObject clon2 = Instantiate(objc2Pref, cañon.position, cañon.rotation);        
                Rigidbody2D rb2dClon2 = clon2.GetComponent<Rigidbody2D>();
                rb2dClon2.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                clon2.gameObject.name = "Coin2";
                Destroy(gameObject);
            }
            if (x == 3)
            {
                StopCoroutine(ActivadordeObjetos());
                GameObject clon3 = Instantiate(objc3Pref, cañon.position, cañon.rotation);
                Rigidbody2D rb2dClon3 = clon3.GetComponent<Rigidbody2D>();
                rb2dClon3.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                clon3.gameObject.name = "Coin3";
                Destroy(gameObject);
            }


        }
    }


}
