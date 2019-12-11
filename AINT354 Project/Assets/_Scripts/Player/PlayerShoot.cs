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
    public AudioClip clip;
    public LineRenderer line;

    AudioSource audio;
    float timer;


    void Awake()
    {
        ammoCount = 30;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetButtonDown("Fire1") && timer >= timeToShoot && ammoCount != 0 && !PauseMenu.isPaused)
        {
            Shoot();
        }
        //else if (Input.GetButtonDown("Fire2"))
        //{
        //    StartCoroutine(DogHit());
        //}

        ammoText.text = "Ammo: " + ammoCount;
    }

    void Shoot()
    {
        ammoCount -= 1;
        timer = 0.0f;
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        audio.PlayOneShot(clip, 0.7f);
    }

    //IEnumerator DogHit()
    //{ 
    //    RaycastHit2D hitInfo = Physics2D.Raycast(shootPoint.position, shootPoint.up, 10);

    //    if (hitInfo)
    //    {
    //        Debug.DrawRay(shootPoint.position, shootPoint.up * 10);

    //        if(hitInfo.transform.tag == "Player")
    //        {
                
    //        }
    //        else
    //        {
    //            Debug.Log(hitInfo.transform.name);
    //            line.SetPosition(0, shootPoint.position);
    //            line.SetPosition(1, hitInfo.point);
    //        }

    //    }
    //    else
    //    {
    //        line.SetPosition(0, shootPoint.position);
    //        line.SetPosition(1, shootPoint.position + shootPoint.up * 10);
    //    }

    //    line.enabled = true;

    //    yield return new WaitForSeconds(0.5f);

    //    line.enabled = false;
    //}
}
