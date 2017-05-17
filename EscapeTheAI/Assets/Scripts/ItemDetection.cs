using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetection : MonoBehaviour {

    public GameObject target;

    void OnTriggerEnter(Collider t)
    {
        if(t.transform.tag == "Item")
        {
            target.SetActive(false);
        }
    }
}
