using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_001 : MonoBehaviour {

    public bool used;
    public int id;
    public int type;
    public float speed;
    public GameObject target;
    public Vector3 targetPos;
    public bool throwButton;

    void OnCollisionEnter(Collision c)
    {
        if (throwButton)
        {
            if(c.transform.tag == "PickUp")
            {
                Press();
            }
        }
    }

    public void Press()
    {
        if (!used)
        {
            used = true;
            switch (type)
            {
                case 0:
                    target.GetComponent<EndDoor_001>().Unlock(id);
                    break;
                case 1:
                    target.GetComponent<ElevatorDoor>().Triggerd(1);
                    break;
                case 2:
                    target.GetComponent<ElevatorDoor>().Triggerd(0);
                    break;
                case 3:
                    target.SetActive(false);
                    break;
            }
            for(int i = 0; i < 10; i++)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                print("Moving Button");
            }
        }
    }
}
