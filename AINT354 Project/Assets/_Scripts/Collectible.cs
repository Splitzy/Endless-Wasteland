using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public int ammoRegen = 0;
    public int healthRegen = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHealth health = col.GetComponent<PlayerHealth>();
            PlayerShoot ammo = col.GetComponent<PlayerShoot>();

            health.currentHealth += healthRegen;
            ammo.ammoCount += ammoRegen;

            health.healthText.text = "" + health.currentHealth;

            
            Destroy(gameObject);    
        }
    }

}
