using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{
    public GameObject showObjetc;

    private void OnMouseDown()
    {
        showObjetc.SetActive(!showObjetc.activeInHierarchy);
        Debug.Log("Me estas presionando");
    }
}
