using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;
    public float timeToShoot = 0.75f;
    public int maxAmmo = 120;
    public int ammoCount;
    public Text ammoText;

    float timer;


    void Awake()
    {
        ammoCount = 30;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetButtonDown("Fire1") && timer >= timeToShoot && ammoCount != 0)
        {
            Shoot();
        }

        ammoText.text = "Ammo: " + ammoCount;
    }

    void Shoot()
    {
        ammoCount -= 1;
        timer = 0.0f;
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
