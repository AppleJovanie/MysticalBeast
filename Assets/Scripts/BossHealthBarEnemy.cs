using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarEnemy : MonoBehaviour
{
    public EnemyHealthBar bossHealth;
    public Image fillImage;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }


    // Call this function whenever the boss's health changes
  
}
