﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoints : MonoBehaviour {

    public Vector3[] checkpoint;
    public int id;

    public void BackToCheckPoint()
    {
        transform.position = checkpoint[id];
    }
}
