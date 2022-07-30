using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    public Rigidbody2D objectToInstanciar;
    public Transform positionToInstanciar;

    public void InstanciarCactu()
    {
        Rigidbody2D clonCactus;
        clonCactus = Instantiate(objectToInstanciar, positionToInstanciar.position,positionToInstanciar.rotation);
    }
}
