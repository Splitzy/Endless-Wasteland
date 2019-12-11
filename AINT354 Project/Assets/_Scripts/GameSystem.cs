using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    GameObject[] enemies;

    public GameObject[] waves;


    // Start is called before the first frame update
    void Start()
    {
        waves[0].SetActive(true);
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
            }

        }

    }
}
