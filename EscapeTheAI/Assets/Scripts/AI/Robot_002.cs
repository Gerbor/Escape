using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_002 : MonoBehaviour {
    public GameObject player;
    public float targetRange;
    public bool hasTarget;
    public int cooldown;
    public bool cooling;
    public float speed;
    public Transform cannon;
    public GameObject ammo;
    RaycastHit hit;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update () {
        Look();
        if (hasTarget)
        {
            Target();
        }
	}

    public void Look()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * targetRange, Color.green);

        Vector3 back = transform.TransformDirection(-Vector3.forward);
        Debug.DrawRay(transform.position, back * targetRange, Color.green);

        Vector3 right = transform.TransformDirection(Vector3.right);
        Debug.DrawRay(transform.position, right * targetRange, Color.green);

        Vector3 left = transform.TransformDirection(Vector3.left);
        Debug.DrawRay(transform.position, left * targetRange, Color.green);

        if(Physics.Raycast(transform.position, back, out hit, targetRange))
        {
            if (hit.transform.tag == "Player")
            {
                Hit();
            }
        }
        if (Physics.Raycast(transform.position, right, out hit, targetRange))
        {
            if (hit.transform.tag == "Player")
            {
                Hit();
            }
        }
        if (Physics.Raycast(transform.position, left, out hit, targetRange))
        {
            if (hit.transform.tag == "Player")
            {
                Hit();
            }
        }

        if (Physics.Raycast(transform.position, fwd, out hit, targetRange))
        {
            Hit();
        }
    }

    public void Hit()
    {
        if (hit.transform.tag == "Player")
        {
            hasTarget = true;
        }
    }

    public void Target()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > targetRange)
        {
            hasTarget = false;
            return;
        }

        Vector3 targetDir = player.transform.position - transform.position;
        Vector3 targetLoc = new Vector3(targetDir.x, 0, targetDir.z);
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetLoc, speed * Time.deltaTime, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (!cooling)
        {
            Instantiate(ammo, cannon.position, Quaternion.identity);
            cooling = true;
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldown);
        cooling = false;
    }
}
