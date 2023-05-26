using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemsWorld : MonoBehaviour
{
    public Item item;

    private void Awake()
    {
        Destroy(gameObject);
        ItemWorld.SpawnItemWorld(transform.position, item);
    }
   
}
