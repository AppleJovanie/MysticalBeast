using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    public float damageAmount = 10f; // Adjust this value based on your game's balancing
    public float delayBeforeDamage = 2f; // Delay in seconds before applying damage
    public GameObject youWonPanel;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // You can add any other logic related to enemy health here
    }

    public void TakeDamage(float damageAmount)
    {
        // Reduce the enemy's health by the damage amount
        currentHealth -= (int)damageAmount;

        // Check if the enemy is dead
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
        if (player != null)
        {
            Playerhealth playerHealth = player.GetComponent<Playerhealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage((int)this.damageAmount);
            }
        }
    }

    void Die()
    {
        // Implement death behavior here (e.g., play death animation, destroy GameObject, etc.)
        Destroy(gameObject);

        // Show the "YouWonPanel" when the enemy dies
        if (youWonPanel != null)
        {
            youWonPanel.SetActive(true);
        }
    }
}
