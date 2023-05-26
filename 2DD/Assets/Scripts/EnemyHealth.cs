using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [Space(20)]
    [SerializeField] private float maxHealth = 100.0f; // Maximum health of the player
    [SerializeField] private float currentHealth; // Current health of the player (starts at maxHealth)

    [Header("UI Settings")]
    [Space(20)]
    [SerializeField] private Image healthBar; // Reference to the health bar Image component
    Item item;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1.0f; // Set the health bar fill amount to 1.0f (full)
    }

    // Function to take damage and update the player's health
    public void TakeDamage(float amount)
    {
        currentHealth -= amount; // Subtract the amount of damage from the player's current health
        currentHealth = Mathf.Max(currentHealth, 0); // Prevent health from going below 0
        healthBar.fillAmount = currentHealth / maxHealth; // Update the health bar fill amount
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Die(); // If the player's health is zero or less, call the Die function
        }
    }

    // Function to handle the player's death
    private void Die()
    {
       
        // Do something to end the game, like show a game over screen or restart the level
        Debug.Log("Enemy has died!");
        // Create a new item to drop
        Item itemToSpawn = new Item();
        itemToSpawn.itemType = Item.ItemType.HealthPotion;
        itemToSpawn.amount = 1;
        // Then call SpawnItemWorld() with itemToSpawn:
        ItemWorld.SpawnItemWorld(transform.position, itemToSpawn);

    }
}
