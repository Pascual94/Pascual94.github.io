using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightingCactus : MonoBehaviour
{
    [SerializeField] Image  lifetime;
    [SerializeField] Text   textLifeTime;
    float                   lifeTimeHP, lifeTimeMaxHP = 1000;

    void Start()
    {
        lifeTimeHP = lifeTimeMaxHP;  
    }


    public void Injured(float amount)
    {
        lifeTimeHP = Mathf.Clamp(lifeTimeHP - amount, 0f, lifeTimeMaxHP);
        lifetime.transform.localScale = new Vector2(lifeTimeHP / lifeTimeMaxHP, 1);
        textLifeTime.text = lifeTimeHP.ToString();

        if(lifeTimeHP<= 0)
        {
            Debug.Log("Ya no nos queda vida");
        }
    }
}
