using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAttack : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;

    [Header("Attack Settings")]
    public float attackRange = 2f;
    public int damage = 10;
    public LayerMask playerLayer;

    [Header("Detection Settings")]
    public float detectionRange = 5f;

    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Detect player in range
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, detectionRange, playerLayer);
        foreach (Collider2D playerCollider in hitPlayers)
        {
            if (playerCollider.CompareTag("Player"))
            {
                player = playerCollider.transform;
                break;
            }

            rb.velocity = Vector2.zero;
        }

        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackRange)
            {
                // Player is in attack range, stop moving
                rb.velocity = Vector2.zero;
            }
            else
            {
                //Calculate direction to player, normalize it, and move the enemy in that direction
                Vector2 direction = player.position - transform.position;
                direction.Normalize();

                rb.velocity = direction * moveSpeed;
            }
        }
        else
        {
            // If player is not found, stop moving
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player enters the enemy's attack range, deal damage
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    // Draw detection and attack ranges in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}