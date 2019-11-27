using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDMG = 10;
    public float timeBetweenAttack = 0.5f;

    GameObject target;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        playerHealth = target.GetComponent<PlayerHealth>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttack && playerInRange && enemyHealth.currentHealth != 0)
        {
            Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == target)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == target)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDMG);
        }
    }
}
