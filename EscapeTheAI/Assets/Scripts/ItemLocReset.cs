using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLocReset : MonoBehaviour {

    Vector3 itemLoc;

    void Start()
    {
        itemLoc = transform.position;
    }

    public void ResetLoc()
    {
        transform.position = itemLoc;
    }
}
