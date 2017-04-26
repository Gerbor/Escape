using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Ball : MonoBehaviour {

    public float speed;

	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
    }
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }
    void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "Player")
        {
            c.transform.GetComponent<PlayerCheckPoints>().BackToCheckPoint();
        }
        Destroy(gameObject, 5);
    }
}
