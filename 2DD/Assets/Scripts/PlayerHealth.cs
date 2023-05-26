using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [Space(20)]
    [SerializeField] private float maxHealth = 100.0f; 
    [SerializeField] private float currentHealth;

    [Header("UI Settings")]
    [Space(20)]
    [SerializeField] private Image healthBar; 

   
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1.0f; 
    }

   
    public void TakeDamage(float amount)
    {
        currentHealth -= amount; 
        currentHealth = Mathf.Max(currentHealth, 0); 
        healthBar.fillAmount = currentHealth / maxHealth; 
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}