using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float flashSpeed;
    public GameObject healthPack, ammoPack;
    public AudioClip clip;
    BoxCollider2D col;
    Color flashColor = new Color(1f, 0f, 0f, 0.5f);

    bool isDead;
    bool damaged;
    float randomNum = 0;
    AudioSource audio;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            gameObject.GetComponent<SpriteRenderer>().color = flashColor;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, Color.white, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        if(isDead)
        {
            return;
        }

        currentHealth -= amount;

        damaged = true;

        audio.PlayOneShot(clip, 0.7f);

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
