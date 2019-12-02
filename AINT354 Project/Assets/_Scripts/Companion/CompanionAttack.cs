using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAttack : MonoBehaviour
{
    public int attackDMG = 10;
    public float timeBetweenAttack = 0.5f;

    GameObject target;
    EnemyHealth enemyHealth;
    CompanionHealth dogHealth;
    bool enemyInRange;
    float timer;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Companion");
        dogHealth = target.GetComponent<CompanionHealth>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttack && enemyInRange && !dogHealth.isLimping)
        {
            Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == target)
        {
            enemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == target)
        {
            enemyInRange = false;
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
