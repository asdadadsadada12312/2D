using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item { 
    
    public enum ItemType
    {
        Weapon,
        Coin,
        HealthPotion,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Weapon:       return ItemsAssets.Instance.weaponSprite;
            case ItemType.HealthPotion: return ItemsAssets.Instance.healthPotionSprite;
            case ItemType.Coin:         return ItemsAssets.Instance.coinSprite;
        }
    }

    public bool isStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Coin:
            case ItemType.HealthPotion:
                return true;
            case ItemType.Weapon:
                return false;
        }
    }
}

