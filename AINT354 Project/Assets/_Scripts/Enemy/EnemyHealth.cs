using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    BoxCollider2D col;

    bool isDead;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        if(isDead)
        {
            return;
        }

        currentHealth -= amount;

        if(currentHealth <=0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        col.isTrigger = true;
        Destroy(gameObject);
    }
}
