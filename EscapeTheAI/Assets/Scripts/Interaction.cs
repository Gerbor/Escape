using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Interaction : MonoBehaviour {

    public bool frozen;
    public GameObject player;
    public bool holding;
    public GameObject pickUpParent;
    GameObject holdObject;
    public int throwSpeed;

    void Start()
    {
        HideCursor();
    }
    void Update()
    {
        if (frozen)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                player.GetComponent<RigidbodyFirstPersonController>().perms.jumpPerm = true;
                player.GetComponent<RigidbodyFirstPersonController>().perms.movePerm = true;
                player.GetComponent<RigidbodyFirstPersonController>().perms.lookPerm = true;
                HideCursor();
            }
        }
        if (holding)
        {
            HoldCheck();
        }
    }
    public void OnTriggerStay(Collider t)
    {
        if(t.transform.tag == "Interact")
        {
            if (Input.GetButtonDown("E"))
            {
                frozen = true;
                player.GetComponent<RigidbodyFirstPersonController>().perms.jumpPerm = false;
                player.GetComponent<RigidbodyFirstPersonController>().perms.movePerm = false;
                player.GetComponent<RigidbodyFirstPersonController>().perms.lookPerm = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        if(t.transform.tag == "Button")
        {
            if (Input.GetButtonDown("E"))
            {
                t.GetComponent<Button_001>().Press();
            }
        }
        if(t.transform.tag == "PickUp")
        {
            if (!holding)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    holding = true;
                    t.transform.SetParent(pickUpParent.transform, true);
                    Rigidbody rb = t.GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                    holdObject = t.gameObject;
                    holdObject.GetComponent<PickUp>().beingHold = true;
                }
            }
        }
    }
    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void HoldCheck()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            DropHold();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            DropHold();
            ThrowHold();
        }
    }
    public void DropHold()
    {
        holding = false;
        holdObject.transform.parent = null;
        Rigidbody rb = holdObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        holdObject.GetComponent<PickUp>().beingHold = false;
    }
    public void ThrowHold()
    {
        Rigidbody rb = holdObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwSpeed);
    }
}
