using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    [SerializeField] Text textCoins;

    int coins;


    void Update()
    {
        /*if (Input.GetButtonDown("Add"))
        {
            IncreaseCoins(20);
            
        }
        if (Input.GetButtonDown("Subtract"))
        {
            DiscountCoins(10);
        }
        */
    }
    public void IncreaseCoins(int coin)
    {
        coins += coin;
        textCoins.text = coins.ToString();
    }

    public void DiscountCoins(int coin)
    {
        coins -= coin;
        textCoins.text = coins.ToString();
    }
}
