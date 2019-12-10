using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Text healthText;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public GameObject GameOver;
    public AudioClip clip;

    AudioSource audio;
    bool isDead;
    bool damaged;

    void Awake()
    {
        currentHealth = startingHealth;
        healthText.text = "" + currentHealth;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthText.text = "" + currentHealth;

        audio.PlayOneShot(clip, 0.7f);

        if(currentHealth <= 0 && !isDead)
        {
            currentHealth = 0;
            healthText.text = "" + currentHealth;
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        GameOver.SetActive(true);

        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerShoot>().enabled = false;
        gameObject.GetComponent<FaceMouse>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }
}
