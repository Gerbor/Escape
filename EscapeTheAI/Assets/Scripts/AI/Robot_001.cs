using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot_001 : MonoBehaviour
{

    NavMeshAgent agent;
    public Vector3[] waypoints;
    public int target;
    public GameObject player;
    public GameObject[] eye;
    public bool targetingPlayer;
    public bool seePlayer;
    public bool decaying;
    public int targetRange;
    public int chasingTime;
    public float chaseSpeed;
    public float chaseAcceleration;
    public AudioSource aClip;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetTarget();
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update () {
        Look();
        if (!targetingPlayer)
        {
            if (transform.position.ToString() == waypoints[target].ToString())
            {
                aClip.Play();
                if (target == waypoints.Length -1)
                {
                    target = 0;
                    SetTarget();
                    return;
                }
                else
                {
                    target++;
                    SetTarget();
                }
            }
        }
        else
        {
            TargetPlayer();
        }
    }

    public void Look()
    {
        Vector3 fwd = eye[0].transform.TransformDirection(Vector3.forward);
        Vector3 fwd1 = eye[1].transform.TransformDirection(Vector3.forward);
        Vector3 fwd2 = eye[2].transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(eye[0].transform.position, fwd * targetRange, Color.green);
        Debug.DrawRay(eye[1].transform.position, fwd1 * targetRange, Color.green);
        Debug.DrawRay(eye[2].transform.position, fwd2 * targetRange, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(eye[0].transform.position, fwd, out hit, targetRange) || Physics.Raycast(eye[1].transform.position, fwd1, out hit, targetRange) ||
            Physics.Raycast(eye[2].transform.position, fwd2, out hit, targetRange))
        {
            if(hit.transform.tag == "Player")
            {
                print("DETECTED PLAYER");
                if (!targetingPlayer)
                {
                    targetingPlayer = true;
                    seePlayer = true;
                }

            }
            else
            {
                CantFindPlayer();
            }
        }
        else
        {
            CantFindPlayer();
        }
    }

    public void CantFindPlayer()
    {
        seePlayer = false;
        if (targetingPlayer)
        {
            if (!decaying)
            {
                print("Started decaying");
                decaying = true;
                StartCoroutine(Decay());
            }
        }
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(chasingTime);
        if (!seePlayer)
        {
            StopChasing();
        }
        decaying = false;
    }

    public void StopChasing()
    {
        print("Stoped Chasing player");
        targetingPlayer = false;
        SetTarget();
        agent.speed = 3.5f;
        agent.acceleration = 8;
    }

    public void TargetPlayer()
    {
        agent.speed = chaseSpeed;
        agent.acceleration = chaseAcceleration;
        agent.SetDestination(player.transform.position);
    }

    public void SetTarget()
    {
        agent.SetDestination(waypoints[target]);
    }
    public void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            player.GetComponent<PlayerCheckPoints>().BackToCheckPoint();
            player.GetComponent<PlayerCheckPoints>().Hit();
            transform.position = waypoints[0];
            StopChasing();
        }
    }
}