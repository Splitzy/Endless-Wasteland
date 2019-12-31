using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    GameObject[] enemies;

    public GameObject WinScreen;

    public GameObject[] waves;

    public Text waveText;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        waves[0].SetActive(true);
        waveText.text = "Wave 1";
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        int i = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        int i = enemies.Length;

        if (i == 0)
        {
            if (waves[0].activeSelf == true)
            {
                waves[0].SetActive(false);
                waves[1].SetActive(true);
                waveText.text = "Wave 2";
            }
            else if (waves[1].activeSelf == true)
            {
                waves[1].SetActive(false);
                waves[2].SetActive(true);
                waveText.text = "Wave 3";
            }
            else if (waves[2].activeSelf == true)
            {
                waves[2].SetActive(false);
                WinScreen.SetActive(true);

                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<PlayerShoot>().enabled = false;
                player.GetComponent<FaceMouse>().enabled = false;
                player.GetComponent<Collider2D>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

        }

    }
}
