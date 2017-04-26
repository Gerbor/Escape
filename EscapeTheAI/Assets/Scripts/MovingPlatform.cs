using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public int target;
    public Vector3[] waypoints;
    public float speed;
    public bool activated;
    public bool doParent;

    void Update()
    {
        if (activated)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target], speed * Time.deltaTime);
        if (transform.position.ToString() == waypoints[target].ToString())
        {
            if (target == waypoints.Length - 1)
            {
                target = 0;
                return;
            }
            else
            {
                target++;
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            if(doParent)
                c.transform.SetParent(gameObject.transform);
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            if (doParent)
                c.transform.SetParent(null);
        }
    }
}
