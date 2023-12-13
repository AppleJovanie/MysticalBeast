using UnityEngine;
using UnityEngine.UI;

public class Playerheatlh : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Text healthText; // Reference to a UI text element to display health (optional)

    void Start()
    {
        currentHealth = maxHealth;

        // Update UI text (optional)
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Update UI text (optional)
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement death behavior (e.g., respawn or game over)
        Debug.Log("Player died");
    }

    void UpdateHealthText()
    {
        // Update UI text with current health value (optional)
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
