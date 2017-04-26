using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RotatingPlatform : MonoBehaviour {

    public float rotateSpeed;
    public bool activated;

	void Update () {
        if (activated)
        {
            Rotate();
        }
	}

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 1 * rotateSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
       //     print(c.transform.eulerAngles.y);
     //       c.transform.GetComponent<RigidbodyFirstPersonController>().perms.lookPerm = false;
            c.transform.SetParent(gameObject.transform, true);
          //  c.transform.GetComponent<RigidbodyFirstPersonController>().perms.lookPerm = true;
         //   print(c.transform.eulerAngles.y);
        }
    }
    
    void OnTriggerExit(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            c.transform.SetParent(null);
        }
    }
}
