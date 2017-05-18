using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuiter : MonoBehaviour {

	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
	}
}
