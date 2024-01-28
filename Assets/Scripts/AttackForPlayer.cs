using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackForPlayer : MonoBehaviour
{
    public float damageAmount = 10f; // Adjust this value based on your game's balancing
    public KeyCode attackKey = KeyCode.Space; // Change this to the desired attack key
    public GameObject targetEnemy; // Reference to the enemy GameObject
    public GameObject panelToDisableAfterAttack;
    public ButtonManager buttonManager;

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
        // Add any additional logic you want to perform when the attack button is pressed
    }

    public void Attack()
    { 
        DisableCanvas();
        if (targetEnemy != null)
        {
            // Assuming the enemy has an EnemyHeallth script attached
            EnemyHealth enemyHealth = targetEnemy.GetComponent<EnemyHealth>();

            // If the object has an EnemyHealth script, reduce its health
            if (enemyHealth != null)
            {
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
