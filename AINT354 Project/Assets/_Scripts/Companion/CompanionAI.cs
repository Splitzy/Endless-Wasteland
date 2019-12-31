using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum DogState { DEFAULT, SEARCH, FETCH }

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
            state = DogState.DEFAULT;
            findMe.target = player.transform;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(state != DogState.DEFAULT)
            {
                return;
            }
            else
            {
                state = DogState.SEARCH;
                Debug.Log("search");
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
                findMe.target = col.gameObject.transform;
                kill = col.gameObject;
                Destroy(kill, 15);
            }
        }
        else if (col.gameObject.tag == "Collectable")
        {
            if(state != DogState.FETCH)
            {
                return;
            }
            else
            {
                findMe.target = col.gameObject.transform;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player Radar")
        {
            lerp.speed = 5;
        }
    }


}
