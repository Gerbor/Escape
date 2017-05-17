using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public bool beingHold;
    public GameObject interactor;

	void OnCollisionEnter(Collision c)
    {
        if (beingHold)
        {
            if(interactor == null)
            {
                interactor = GameObject.FindGameObjectWithTag("Interactor");
            }
            interactor.GetComponent<Interaction>().DropHold();
        }
    }
}
