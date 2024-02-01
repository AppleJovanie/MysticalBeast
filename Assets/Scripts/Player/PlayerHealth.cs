using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerhealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Text healthText; // Reference to a UI text element to display health (optional)
    public GameObject panelToEnableAfterDamage; // Reference to the panel you want to enable
    public ButtonManager buttonManager;
    public GameObject gameOverPanel;

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
        else
        {
            // Enable the panel after taking damage
            EnablePanelAfterDamage();
        }
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
        SceneManager.LoadScene(2);
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
        if (buttonManager != null)
        {
            buttonManager.HideImages(); // Call the HideImages method from the ButtonManager
        }
    }
}
