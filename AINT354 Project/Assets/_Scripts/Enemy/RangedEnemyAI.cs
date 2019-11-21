using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public float timeBetweenShot = 0.75f;
    public Transform bulletSpawn;
    public GameObject bullet;

    Transform target;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(target != null)
        {
            Look();
        }
        else if (target != null && timer >= timeBetweenShot)
        {
            Look();
            Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Look()
    {
        transform.LookAt(target);
        transform.Rotate(new Vector3(0f, -90f, 0f), Space.Self);
    }

    void Fire()
    {
        timer = 0f;
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }
}
