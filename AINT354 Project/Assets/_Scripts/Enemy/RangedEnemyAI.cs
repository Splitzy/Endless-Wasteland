using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public float timeBetweenShot = 0.75f;
    public Transform bulletSpawn;
    public GameObject bullet;
    public AudioClip clip;
    public Transform target;

    AudioSource audio;
    float timer;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(target != null)
        {
            Look();

            if (timer >= timeBetweenShot)
            {
                Fire();
            }
        }



        //else if (target != null && timer >= timeBetweenShot)
        //{
        //    Look();
        //    Fire();
        //}
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "Player")
        {
            target = col.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    void Look()
    {
        transform.LookAt(target);
        transform.Rotate(new Vector3(0f, -90f, 0f), Space.Self);
    }

    void Fire()
    {
        audio.PlayOneShot(clip, 0.7f);
        timer = 0f;
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }
}
