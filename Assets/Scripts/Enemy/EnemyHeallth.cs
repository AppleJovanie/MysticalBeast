using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeallth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}