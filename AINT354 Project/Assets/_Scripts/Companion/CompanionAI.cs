using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CompanionAI : MonoBehaviour
{
    Pathfinding.AIDestinationSetter findMe;
    Pathfinding.AILerp lerp;
    GameObject kill, player;
    bool isAttacking, isAlert, isSearching, isFetching, isDefault = false;


    void Start()
    {
        lerp = GetComponent<AILerp>();
        findMe = GetComponent<AIDestinationSetter>();
        isDefault = true;
        player = GameObject.FindGameObjectWithTag("Player");
        findMe.target = player.transform;
    }

    void Update()
    { 
        if (kill == null)
        {
            DefaultState();
            //Debug.Log("I am at Default! Woof!");
        }
        else if (findMe.target == null)
        {
            DefaultState();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && isDefault)
        {
            isAlert = true;
            Debug.Log("I am angry! Bark!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && isDefault)
        {
            isSearching = true;
            Debug.Log("I smell something! Awoo!");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && isDefault)
        {
            isFetching = true;
            Debug.Log("Must bring master treats! Woof!");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player Radar")
        {
            lerp.speed = 0;
        }
        else if (col.gameObject.tag == "Explore" && isSearching)
        {
            findMe.target = GameObject.FindGameObjectWithTag("Explore").transform;
            kill = GameObject.FindGameObjectWithTag("Explore");
            lerp.speed = 5;
            Destroy(kill, 15);
        }
        else if (col.gameObject.tag == "Enemy" && isAlert)
        {
            AttackState();
        }
        else if (col.gameObject.tag == "Collectible" && isFetching)
        {
            findMe.target = GameObject.FindGameObjectWithTag("Collectible").transform;

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player Radar")
        {
            lerp.speed = 3;
        }
    }

    void AttackState()
    {
        isAttacking = true;
        findMe.target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void DefaultState()
    {
        findMe.target = player.transform;
        isAttacking = false;
        isFetching = false;
        isSearching = false;
        isAlert = false;
        isDefault = true;
    }
}
