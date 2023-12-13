using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyHeallth enemyHealth;
    public Image fillImage;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>(); 
    }
    private void Update()
    {
        if (enemyHealth != null) { 
        float fillValue = enemyHealth.currentHealth / (float)enemyHealth.maxHealth;
        slider.value = fillValue;

            if (enemyHealth.currentHealth <= 5)
            {
                fillImage.color = Color.yellow;
            }
            else { 
                fillImage.color = Color.red;
            }
            if (fillValue <= slider.minValue)
            {
                fillImage.enabled = false;
            }
            else if (!fillImage.enabled)
            {
                fillImage.enabled = true;
            }

        }
    }

}
