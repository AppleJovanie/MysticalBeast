using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Playerhealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Text healthText; // Reference to a UI text element to display health (optional)
    public GameObject panelToEnableAfterDamage; // Reference to the panel you want to enable
    public GameObject gameOverPanel;
    public Text attackIndicatorText;
    public Renderer PlayerRenderer;
    public float blinkDuration = 1f; // Duration for blinking animation
    public float blinkInterval = 0.1f; // Interval for blinking animation
    public Color blinkColor = Color.red; // Color for blinking animation
    private Color originalColor;

    public AudioSource audioSource;
    public AudioClip playerHitSound; // Sound effect for player taking damage

    private Coroutine attackTextCoroutine;
    public GameObject player;

    public ButtonManager btnManager; // Reference to Button Manager

    // Added boolean to check if damage was received
    private bool hasTakenDamage = false;

    void Start()
    {
        currentHealth = maxHealth;
       

        // Update UI text (optional)
        UpdateHealthText();

        // Disable the attack indicator text initially
        if (attackIndicatorText != null)
        {
            attackIndicatorText.gameObject.SetActive(false);
        }

        // Check if the player should spawn at the saved position
        if (PlayerPrefs.HasKey("SpawnAtSavedPosition") && PlayerPrefs.GetInt("SpawnAtSavedPosition") == 1)
        {
            float x = PlayerPrefs.GetFloat("SavedPositionX");
            float y = PlayerPrefs.GetFloat("SavedPositionY");
            float z = PlayerPrefs.GetFloat("SavedPositionZ");
            transform.position = new Vector3(x, y, z);

            // Clear the spawn flag
            PlayerPrefs.DeleteKey("SpawnAtSavedPosition");
        }

        if (PlayerRenderer != null)
        {
            originalColor = PlayerRenderer.material.color;
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Update UI text (optional)
        UpdateHealthText();

        

        if (PlayerRenderer != null)
        {
            
            StartCoroutine(Blink());
        }

        // Play the sound effect for player taking damage
        if (audioSource != null && playerHitSound != null)
        {
            audioSource.PlayOneShot(playerHitSound);
        }

        if (currentHealth <= 0)
        {
            Die();

        }
        else
        {
            // Re-enable card elements to allow interaction when it's the player's turn to attack
            Debug.Log("Test");
            btnManager.SetCardElementsInteractable(true); // Allow interaction
            

            // Enable the panel after taking damage
            EnablePanelAfterDamage();

            // Show attack indicator text
            if (attackIndicatorText != null)
            {
                // Reset text visibility

                attackIndicatorText.gameObject.SetActive(true);
                attackIndicatorText.text = "Your Turn to Attack!";

                // Start or restart the fade-out coroutine
                if (attackTextCoroutine != null)
                {
                    StopCoroutine(attackTextCoroutine);
                }
                attackTextCoroutine = StartCoroutine(FadeOutAttackText());
            }
        }


    }

    IEnumerator FadeOutAttackText()
    {
        // Wait for 1.5 seconds
        yield return new WaitForSeconds(1.5f);

        attackIndicatorText.text = ""; // Clear the text
    }

    IEnumerator Blink()
    {
        float timer = 0f;
        bool isVisible = true;

        while (timer < blinkDuration)
        {
            PlayerRenderer.material.color = isVisible ? blinkColor : originalColor;
            isVisible = !isVisible;

            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }

        // Restore the original color after blinking animation
        PlayerRenderer.material.color = originalColor;
    }

    void Die()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Debug.Log("Player died");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void UpdateHealthText()
    {
        // Update UI text with current health value (optional)
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    void EnablePanelAfterDamage()
    {
        if (panelToEnableAfterDamage != null)
        {
            ResetSnapAreas();
            panelToEnableAfterDamage.SetActive(true);
        }
    }

    void ResetSnapAreas()
    {
        // Reset snap areas logic goes here
        if (btnManager != null)
        {
            
            btnManager.HideImages(); // Call the HideImages method from the ButtonManager
        }
    }
}
