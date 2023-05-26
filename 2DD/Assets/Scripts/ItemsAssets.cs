using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAssets : MonoBehaviour
{
    public static ItemsAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform itemWorld;

    public Sprite weaponSprite;
    public Sprite healthPotionSprite;
    public Sprite coinSprite;
}
