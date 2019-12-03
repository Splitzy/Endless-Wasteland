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

            if(health.currentHealth != health.startingHealth)
            {
                health.currentHealth += healthRegen;
                Destroy(gameObject);
            }


            if(ammo.ammoCount != ammo.maxAmmo)
            {
                ammo.ammoCount += ammoRegen;
                Destroy(gameObject);
            }
            
            health.healthText.text = "" + health.currentHealth;       
               
        }
    }

}
