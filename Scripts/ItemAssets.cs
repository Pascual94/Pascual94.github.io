using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; set; }

    void Awake()
    {
        Instance = this;
    }

    public Sprite swordSprite;
    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite coinSprite;
    public Sprite mediKitSprite;

    public Transform pfItemWorld;
}
