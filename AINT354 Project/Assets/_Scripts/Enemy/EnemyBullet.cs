using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10;
    public int bulletDMG = 20;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();

        CompanionHealth companion = hitInfo.GetComponent<CompanionHealth>();

        if (player != null)
        {
            player.TakeDamage(bulletDMG);
            
        }
        else if (companion != null)
        {
            companion.TakeDamage(bulletDMG);
            //Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
