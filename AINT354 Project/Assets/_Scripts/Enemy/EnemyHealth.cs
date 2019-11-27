using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public GameObject healthPack, ammoPack;
    BoxCollider2D col;

    bool isDead;
    float randomNum = 0;

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
        DropItem();
        Destroy(gameObject); 
    }

    void DropItem()
    {
        randomNum = Random.Range(0.0f, 1.0f);

        if (randomNum <= 0.25f)
        {
            Instantiate(healthPack, this.transform.position, this.transform.rotation);
        }
        else if (randomNum > 0.25f && randomNum <= 0.50f)
        {
            Instantiate(ammoPack, this.transform.position, this.transform.rotation);
        }

        randomNum = 0;
    }
}
