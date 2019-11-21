using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CompanionAI : MonoBehaviour
{
    Pathfinding.AIDestinationSetter findMe;
    Pathfinding.AILerp lerp;
    GameObject kill;


    private void Start()
    {
        lerp = GetComponent<AILerp>();
        findMe = GetComponent<AIDestinationSetter>();
    }

    void Update()
    { 
        if (kill == null || findMe.target == null)
        {
            findMe.target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player Radar")
        {
            lerp.speed = 0;
        }
        else if (col.gameObject.tag == "Explore")
        {
            findMe.target = GameObject.FindGameObjectWithTag("Explore").transform;
            kill = GameObject.FindGameObjectWithTag("Explore");
            lerp.speed = 5;
            Destroy(kill, 15);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            findMe.target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player Radar")
        {
            lerp.speed = 3;
        }
    }
}
