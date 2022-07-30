using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Sword,
        HealthPotion,
        ManaPotion,
        Coin,
        MedKit,
    }
    public ItemType     itemType;
    public int          amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
            case ItemType.MedKit:       return ItemAssets.Instance.mediKitSprite;
        }

    }  
    
    public Color GetColor()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:        return new Color(0,0,0);
            case ItemType.HealthPotion: return new Color(1,0,0);
            case ItemType.ManaPotion:   return new Color(0,0,1);
            case ItemType.Coin:         return new Color(1,1,0);
            case ItemType.MedKit:       return new Color(0,1,1);
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Coin:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
                return true;

            case ItemType.Sword:
            case ItemType.MedKit:
                return false;
        }
    }
    public bool Colocable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:
            case ItemType.MedKit:
                return true;
            case ItemType.Coin:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
                return false;
        }
    }
}

