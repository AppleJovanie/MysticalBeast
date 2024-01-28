using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Playerhealth playerHealth; // Corrected the typo in the class name
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        // You can initialize or set up anything needed here
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null)
        {
            float fillValue = playerHealth.currentHealth / (float)playerHealth.maxHealth;
            slider.value = fillValue;

            if (playerHealth.currentHealth <= 5)
            {
                fillImage.color = Color.yellow;
            }
            else
            {
                fillImage.color = Color.red; // Set the color back to white if health is above 5
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
