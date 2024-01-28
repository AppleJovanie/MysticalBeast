using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyHealth enemyHealth; // Assuming the correct class name is EnemyHealth
    public Image fillImage;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    // Call this function whenever the enemy's health changes
    public void UpdateHealthBar()
    {
        if (enemyHealth != null)
        {
            float fillValue = enemyHealth.currentHealth / (float)enemyHealth.maxHealth;
            slider.value = fillValue;

            if (enemyHealth.currentHealth <= 5)
            {
                fillImage.color = Color.yellow;
            }
            else
            {
                fillImage.color = Color.red;
            }

            fillImage.enabled = (fillValue > slider.minValue); // Simplified visibility check
        }
    }
}
