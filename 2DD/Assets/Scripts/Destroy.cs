using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int damage = 10; //  оличество урона, наносимого игроку
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    private void Start()
    {
        Destroy(gameObject,5f);
    }
}
