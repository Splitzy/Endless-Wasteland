﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;

    Transform target;

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Movement();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

    }

    void Movement()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0f, -90f, 0f), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

}
