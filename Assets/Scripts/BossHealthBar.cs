using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthBar : MonoBehaviour
{
    public BossEnemyHealth bossHealth;
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

    // Call this function whenever the boss's health changes
    public void UpdateHealthBar()
    {
        if (bossHealth != null)
        {
            float fillValue = bossHealth.currentHealth / (float)bossHealth.maxHealth;
            slider.value = fillValue;

            // Adjust color based on boss's health percentage
            if (fillValue <= 0.25f) // Health is less than or equal to 25%
            {
                fillImage.color = Color.red;
            }
            else if (fillValue <= 0.5f) // Health is less than or equal to 50%
            {
                fillImage.color = Color.yellow;
            }
            else // Health is above 50%
            {
                fillImage.color = Color.green;
            }

            fillImage.enabled = (fillValue > slider.minValue); // Simplified visibility check
        }
    }
}
