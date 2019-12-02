using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int regen = 5;
    public bool isLimping;
    BoxCollider2D col;
    bool isRegen;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLimping && currentHealth != startingHealth && !isRegen)
        {
            StartCoroutine(RegenHealth());
        }

        isLimping = false;
        col.isTrigger = false;
    }

    public void TakeDamage(int amount)
    {
        if(isLimping)
        {
            return;
        }

        currentHealth -= amount;

        if(currentHealth <= 10)
        {
            Limp();
        }
    }

    void Limp()
    {
        isLimping = true;
        col.isTrigger = true;
    }

    private IEnumerator RegenHealth()
    {
        isRegen = true;
        while (currentHealth < startingHealth)
        {
            RegenCalc();
            yield return new WaitForSeconds(1);
        }
        isRegen = false;
    }

    void RegenCalc()
    {
        currentHealth += regen;
    }
}
