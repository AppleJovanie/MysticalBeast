using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackForPlayer : MonoBehaviour
{
    private int damageAmount; // Adjust this value based on your game's balancing
    public KeyCode attackKey = KeyCode.Space; // Change this to the desired attack key
    public GameObject targetEnemy; // Reference to the enemy GameObject
    public GameObject panelToDisableAfterAttack;
    public ButtonManager buttonManager;
    public float criticalChance = 0.3f; // Critical hit chance (30%)

    void Update()
    {
        // Check if the attack key is pressed
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    public void SetTargetEnemy(GameObject enemy)
    {
        targetEnemy = enemy;
    }

    public void DisableCanvas()
    {
        if (panelToDisableAfterAttack != null)
        {
            panelToDisableAfterAttack.SetActive(false);
        }
    }

    // Call this method when the attack button is pressed
    public void OnAttackButtonPressed()
    {
        DisableCanvas();
    }

    public void Attack()
    {
        damageAmount = Random.Range(5, 10);
        bool isCritical = Random.value < criticalChance; // Check if the attack is critical

        if (isCritical)
        {
            // Apply critical damage (e.g., double the damage)
            damageAmount *= 2;
            Debug.Log("Critical Hit!");
        }

        if (targetEnemy != null)
        {
            // Assuming the enemy has an EnemyHealth script attached
            EnemyHealth enemyHealth = targetEnemy.GetComponent<EnemyHealth>();

            // If the object has an EnemyHealth script, reduce its health
            if (enemyHealth != null)
            {
                Debug.Log("Damage: " + damageAmount);
                enemyHealth.TakeDamage(damageAmount);
            }
        }

        ResetSnapAreas();
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
