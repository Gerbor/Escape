using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrigger : MonoBehaviour {

    public Animator anim;
    public GameObject quiter;

    void OnTriggerEnter(Collider t)
    {
        if(t.transform.tag == "Player")
        {
            anim.SetBool("Fade", true);
            quiter.SetActive(true);
        }
    }
}
