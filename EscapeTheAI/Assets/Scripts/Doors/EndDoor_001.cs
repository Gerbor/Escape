using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor_001 : MonoBehaviour {

    public bool[] locks;

    public void Unlock (int i)
    {
        locks[i] = true;
        if(locks[0] && locks[1])
        {
            gameObject.SetActive(false);
        }
    }
}
