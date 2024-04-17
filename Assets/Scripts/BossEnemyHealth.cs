using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyHealth : MonoBehaviour
{
    public int maxHealth = 500; // Adjust the max health for the boss
    public int currentHealth;
    public float damageAmount = 20f; // Adjust this value based on your game's balancing
    public float delayBeforeDamage = 2f; // Delay in seconds before applying damage
    public GameObject player;
    public GameObject youWonPanel;

    public AudioSource audioSource;
    public AudioClip destroyHealth;

    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        // Reduce the boss's health by the damage amount
        currentHealth -= (int)damageAmount;

        // Play the destroyHealth audio clip
        if (audioSource != null && destroyHealth != null)
        {
            audioSource.PlayOneShot(destroyHealth);
        }

        // Check if the boss is dead
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Invoke the counter-attack on the player after a delay
            Invoke("CounterAttackPlayer", delayBeforeDamage);
        }
    }

    void CounterAttackPlayer()
    {
        // Generate a random damage amount between 10 and 20 for the boss's counter-attack
        float randomDamage = Random.Range(10f, 20f);

        if (player != null)
        {
            Playerhealth playerHealth = player.GetComponent<Playerhealth>();
            if (playerHealth != null)
            {
                // Reduce the player's health by the random damage amount
                playerHealth.TakeDamage((int)randomDamage);
            }
        }
    }

    void Die()
    {
        // Implement death behavior here (e.g., play death animation, trigger game over, etc.)
        // For now, let's just deactivate the boss GameObject
        gameObject.SetActive(false);

        // Show the "YouWonPanel" when the boss dies
        if (youWonPanel != null)
        {
            youWonPanel.SetActive(true);
        }
    }
}
