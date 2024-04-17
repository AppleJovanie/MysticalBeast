using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    public float damageAmount = 10f; // Adjust this value based on your game's balancing
    public float delayBeforeDamage = 2f; // Delay in seconds before applying damage
    public GameObject youWonPanel;
    public float blinkDuration = 1f; // Duration for blinking animation
    public float blinkInterval = 0.1f; // Interval for blinking animation
    public Color blinkColor = Color.red; // Color for blinking animation
    public Renderer enemyRenderer; // Reference to the Renderer component of the enemy

    public Text damageReceivedText;

    private ButtonManager buttonManager; // Reference to the ButtonManager script
    private Color originalColor; // Original color of the enemy
    public Animator animator;

    public AudioSource audioSource;
    public AudioClip destroyHealth;

    void Start()
    {
        currentHealth = maxHealth;

        // Get the ButtonManager script attached to the player
        if (player != null)
        {
            buttonManager = player.GetComponent<ButtonManager>();
        }

        // Store the original color of the enemy
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    void Update()
    {
        // You can add any other logic related to enemy health here
    }

    public void TakeDamage(float damageAmount)
    {
        // Reduce the enemy's health by the damage amount
        currentHealth -= (int)damageAmount;

        // Play the destroyHealth audio clip
        if (audioSource != null && destroyHealth != null)
        {
            audioSource.PlayOneShot(destroyHealth);
        }

        // Start blinking animation
        if (enemyRenderer != null)
        {
            StartCoroutine(Blink());
        }

        // Check if the enemy is dead
        if (currentHealth <= 0 && damageReceivedText != null)
        {
            Die();
            damageReceivedText.text = "Damage Received: " + damageAmount.ToString();
        }
        else
        {
            // Invoke the counter-attack on the player after a delay
            Invoke("CounterAttackPlayer", delayBeforeDamage);
        }
    }

    IEnumerator Blink()
    {
        float timer = 0f;
        bool isVisible = true;

        while (timer < blinkDuration)
        {
            enemyRenderer.material.color = isVisible ? blinkColor : originalColor;
            isVisible = !isVisible;

            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }

        // Restore the original color after blinking animation
        enemyRenderer.material.color = originalColor;
    }

    void CounterAttackPlayer()
    {
        // Generate a random damage amount between 4 and 10
        float randomDamage = Random.Range(5f, 10f);

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
        // Implement death behavior here (e.g., play death animation, destroy GameObject, etc.)
        Destroy(gameObject);

        // Show the "YouWonPanel" when the enemy dies
        if (youWonPanel != null)
        {
            youWonPanel.SetActive(true);
        }
    }
}
