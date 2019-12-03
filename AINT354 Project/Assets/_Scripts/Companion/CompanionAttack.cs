using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAttack : MonoBehaviour
{
    public int attackDMG = 10;
    public float timeBetweenAttack = 0.5f;

    GameObject target;
    EnemyHealth enemyHealth;
    bool enemyInRange;
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttack && enemyInRange)
        {
            Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
            enemyHealth = col.GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemyInRange = false;
            enemyHealth = null;
        }
    }

    void Attack()
    {
        timer = 0f;

        if (enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDMG);
        }
    }
}
