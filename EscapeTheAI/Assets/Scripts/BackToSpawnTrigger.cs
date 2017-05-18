using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSpawnTrigger : MonoBehaviour {

    public AudioSource fall;

    public void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == "Player")
        {
            fall.Play();
            c.transform.GetComponent<PlayerCheckPoints>().BackToCheckPoint(); 
        }
        if(c.transform.tag == "Item")
        {
            c.transform.GetComponent<ItemLocReset>().ResetLoc();
        }
    }
}
