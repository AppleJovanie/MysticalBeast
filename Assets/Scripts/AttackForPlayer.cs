using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttackForPlayer : MonoBehaviour
{
    [SerializeField] private int damageAmount; // Adjust this value based on your game's balancing
    public KeyCode attackKey = KeyCode.Space; // Change this to the desired attack key
    public GameObject targetEnemy; // Reference to the enemy GameObject
    public GameObject panelToDisableAfterAttack;
    public ButtonManager buttonManager;
    public float criticalChance = 0.2f; // Critical hit chance (20%)

    public Text damageIndicatorText; // Reference to the shared UI Text element
    public Text criticalHitText; // Reference to the text element for critical hit message
    private Coroutine criticalHitCoroutine;
    private Coroutine damageIndicatorCoroutine;

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

        // Reset text visibility before triggering the attack
        if (damageIndicatorText != null)
        {
            damageIndicatorText.gameObject.SetActive(true);
            if (damageIndicatorCoroutine != null)
            {
                StopCoroutine(damageIndicatorCoroutine);
            }
        }

        if (isCritical)
        {
            // Apply critical damage (e.g., double the damage)
            int criticalDamage = damageAmount * 2; // Calculate the critical damage amount
            if (criticalHitText != null)
            {
                criticalHitText.text = "Critical Hit! Critical Damage: " + criticalDamage;

                // Stop previous coroutine if it's running
                if (criticalHitCoroutine != null)
                {
                    StopCoroutine(criticalHitCoroutine);
                }
                criticalHitCoroutine = StartCoroutine(FadeOutTextAfterDelay(criticalHitText));
            }
            // Update the damageAmount variable with the critical damage
            damageAmount = criticalDamage;
        }

        if (targetEnemy != null)
        {
            // Assuming the enemy has an EnemyHealth script attached
            EnemyHealth enemyHealth = targetEnemy.GetComponent<EnemyHealth>();

            // If the object has an EnemyHealth script, reduce its health
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }

        // Update damage indicator text
        if (damageIndicatorText != null)
        {
            damageIndicatorText.text = "Damage: " + damageAmount.ToString();
            // Start the coroutine to clear damage indicator text
            damageIndicatorCoroutine = StartCoroutine(FadeOutTextAfterDelay(damageIndicatorText));
        }

        ResetSnapAreas();
    }


    IEnumerator FadeOutTextAfterDelay(Text text)
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Clear the text
        text.text = "";
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
