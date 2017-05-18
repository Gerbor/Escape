using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizer : MonoBehaviour {

    public GameObject[] cubes;
    public GameObject[] enemies;
    public GameObject[] floors;
    public GameObject[] interacts;
    public GameObject[] pickups;

    public void Optimize(int i)
    {
        switch (i)
        {
            case 0:
                //Remove everything from stage1
                enemies[0].SetActive(false);
                cubes[0].SetActive(false);
                floors[0].SetActive(false);
                //Load Stage 2
                floors[1].SetActive(true);
                cubes[1].SetActive(true);
                enemies[1].SetActive(true);
                break;
            case 1:
                //Remove stage 2
                enemies[1].SetActive(false);
                cubes[1].SetActive(false);
                floors[1].SetActive(false);
                //Load stage 3
                floors[2].SetActive(true);
                cubes[2].SetActive(true);
                enemies[2].SetActive(true);
                break;
            case 2:
                //Remove stage 3
                enemies[2].SetActive(false);
                cubes[2].SetActive(false);
                floors[2].SetActive(false);
                //Load stage 4
                floors[3].SetActive(true);
                cubes[3].SetActive(true);
                break;
            case 3:
                //remove stage 4
                cubes[3].SetActive(false);
                floors[3].SetActive(false);
                //load stage 5
                floors[4].SetActive(true);
                cubes[4].SetActive(true);
                break;
            case 4:
                //remove stage 5
                cubes[4].SetActive(false);
                floors[4].SetActive(false);
                //load stage 6
                floors[5].SetActive(true);
                cubes[5].SetActive(true);
                break;
            case 5:
                //remove stage 6
                cubes[5].SetActive(false);
                floors[5].SetActive(false);
                //load stage 7
                floors[6].SetActive(true);
                cubes[6].SetActive(true);
                pickups[0].SetActive(true);
                interacts[0].SetActive(true);
                break;
            case 6:
                //remove stage 7
                cubes[6].SetActive(false);
                pickups[0].SetActive(false);
                interacts[0].SetActive(false);
                floors[6].SetActive(false);
                //load stage 8
                floors[7].SetActive(true);
                cubes[7].SetActive(true);
                enemies[3].SetActive(true);
                pickups[1].SetActive(true);
                interacts[1].SetActive(true);
                break;
        }
    }
}
