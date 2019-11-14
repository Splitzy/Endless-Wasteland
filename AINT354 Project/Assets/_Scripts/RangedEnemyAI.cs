using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    Transform target;
    void Update()
    {
        if(target != null)
        {
            Look();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Look()
    {
        transform.LookAt(target);
        transform.Rotate(new Vector3(0f, -90f, 0f), Space.Self);
    }
}
