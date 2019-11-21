using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        float angle = AngleBetweenTwoPoints(transform.position, mousePosition);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
