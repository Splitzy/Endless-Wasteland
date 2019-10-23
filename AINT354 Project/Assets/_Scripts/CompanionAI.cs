using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CompanionAI : MonoBehaviour
{
    Pathfinding.AILerp script;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player Radar")
        {
            script.speed = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player Radar")
        {
            script.speed = 3;
        }
    }
}
