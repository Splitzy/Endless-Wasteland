using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Movement();
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
