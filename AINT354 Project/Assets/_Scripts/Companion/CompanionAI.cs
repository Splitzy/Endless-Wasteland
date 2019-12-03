using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum DogState { DEFAULT, ALERT, ATTACK, SEARCH, FETCH }

public class CompanionAI : MonoBehaviour
{
    Pathfinding.AIDestinationSetter findMe;
    Pathfinding.AILerp lerp;
    GameObject kill, player;
    DogState state;

    void Start()
    {
        lerp = GetComponent<AILerp>();
        findMe = GetComponent<AIDestinationSetter>();
        state = DogState.DEFAULT;
        player = GameObject.FindGameObjectWithTag("Player");
        findMe.target = player.transform;
    }

    void Update()
    { 
        if (findMe.target == null)
        {
            //Debug.Log("I am at Default! Woof!");
            state = DogState.DEFAULT;
            findMe.target = player.transform;
            lerp.speed = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(state != DogState.DEFAULT)
            {
                return;
            }
            else
            {
                state = DogState.ALERT;
                Debug.Log("alert");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (state != DogState.DEFAULT)
            {
                return;
            }
            else
            {
                state = DogState.SEARCH;
                Debug.Log("search");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (state != DogState.DEFAULT)
            {
                return;
            }
            else
            {
                state = DogState.FETCH;
                Debug.Log("fetch");
            }
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
            if(state != DogState.SEARCH)
            {
                return;
            }
            else
            {
                findMe.target = GameObject.FindGameObjectWithTag("Explore").transform;
                kill = GameObject.FindGameObjectWithTag("Explore");
                lerp.speed = 5;
                Destroy(kill, 15);
            }
        }
        else if (col.gameObject.tag == "Enemy")
        {
            if (state != DogState.ALERT)
            {
                return;
            }
            else
            {
                state = DogState.ATTACK;
                findMe.target = GameObject.FindGameObjectWithTag("Enemy").transform;
                lerp.speed = 5;
                Debug.Log("attack");
            }
        }    
        else if (col.gameObject.tag == "Collectible")
        {
            if(state != DogState.FETCH)
            {
                return;
            }
            else
            {
                findMe.target = GameObject.FindGameObjectWithTag("Collectible").transform;
                
            }
            
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
