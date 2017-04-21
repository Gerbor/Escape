using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Interaction : MonoBehaviour {

    public bool frozen;
    public GameObject player;

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
                HideCursor();
            }
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
    }
    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
