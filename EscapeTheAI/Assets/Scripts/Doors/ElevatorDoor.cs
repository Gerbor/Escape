using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour {

    public Vector3[] doorPos; //0 = closed, 1 = open
    public float speed;

    public bool opening;
    public bool closing;
    public bool byPlayer;

    public int playerTpHeight;

    public GameObject player;
    public GameObject secondElevator;

    public int selection;

    void Update()
    {
        if(opening || closing)
        {
            OpenClose(selection);
        }
    }

    public void Triggerd(int i)
    {
        byPlayer = true;
        selection = i;
        if (i == 0)
        {
            closing = true;
        }
        else
        {
            opening = true;
        }
    }

	public void OpenClose(int i)
    {
        transform.position = Vector3.MoveTowards(transform.position, doorPos[i], speed * Time.deltaTime);
        if (transform.position.ToString() == doorPos[i].ToString())
        {
            print("MovingDoor");
            if(i == 0)
            {
                closing = false;
                if (byPlayer)
                {
                    StartCoroutine(Transport());
                }
            }
            else
            {
                opening = false;
            }
            byPlayer = false;
        }
    }

    IEnumerator Transport()
    {
        yield return new WaitForSeconds(5);
        TransportPlayer();

    }

    public void TransportPlayer()
    {
        player.transform.position += new Vector3(0,playerTpHeight,0);
        player.GetComponent<PlayerCheckPoints>().id++;
        secondElevator.GetComponent<ElevatorDoor>().selection = 1;
        secondElevator.GetComponent<ElevatorDoor>().opening = true;
    }
}
