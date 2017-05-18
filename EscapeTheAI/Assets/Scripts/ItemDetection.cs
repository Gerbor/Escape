using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetection : MonoBehaviour {

    public GameObject target;
    public int type;

    void OnTriggerEnter(Collider t)
    {
        if(t.transform.tag == "Item")
        {
            if(type == 0)
            {
                target.SetActive(false);
            }
            else
            {
                target.GetComponent<MovingPlatform>().activated = true;
            }
            
        }
    }
}
