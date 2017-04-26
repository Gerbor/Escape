using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSpawnTrigger : MonoBehaviour {

    public void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.GetComponent<PlayerCheckPoints>().BackToCheckPoint();
        }
    }
}
