using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject onButton;
    [SerializeField] GameObject offButton;

    [Header("Objeto a desactivar")]
    public GameObject objecto;

    Collider2D mycol;
    internal object OnClick;

    void Awake()
    {
        offButton.SetActive(false);
        mycol   = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            OfButton();
        }    
    }

    private void OfButton()
    {
        onButton.SetActive(false);
        offButton.SetActive(true);
        mycol.enabled =   false;
        objecto.SetActive(false);
    }
}
