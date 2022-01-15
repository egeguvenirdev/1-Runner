using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //exit and enter triggers
    public bool playerEnter = false;
    public bool playerExit = false;
    private bool droneInstantiate = false;

    //random number variables
    private int randomRock;
    private int randomTransform;
    private Transform rockPosition;
    private static int droneCounter = 0;

    //fallin rocks & drones and their random transforms
    public GameObject[] fallinRocks;
    public GameObject drone;
    public Transform[] droneInstantiateTransforms;
    public Transform[] rockInstantiateTransforms;

    //maze blocks
    public GameObject[] maze;

    //when player has entered the lv
    public void EnterMethod()
    {
        playerEnter = true;
        droneInstantiate = true;

        DroneSpawner();
        StartCoroutine(DropRocks());

    }

    public void ExitMethod()
    {
        playerExit = true;
        playerEnter = false;
    }

    public void LvMover(int lvCount)
    {
        maze[lvCount].transform.position += new Vector3(0, 0, 1200f);
    }

    private void DroneSpawner()
    {
        if (droneInstantiate == true)
        {
            for (droneCounter = 0; droneCounter < 4; droneCounter++)
            {
                Instantiate(drone, droneInstantiateTransforms[droneCounter].transform.position, 
                    droneInstantiateTransforms[droneCounter].transform.rotation);
            }
            droneInstantiate = false;
        }
    }

    //starting the fallin rocks
    IEnumerator DropRocks()
    {
        while (playerEnter)
        {
            randomRock = Random.Range(0, (fallinRocks.Length));

            randomTransform = Random.Range(0, (rockInstantiateTransforms.Length));

            rockPosition = rockInstantiateTransforms[randomTransform];


            Instantiate(fallinRocks[randomRock], rockPosition.transform.position, rockPosition.transform.rotation);
            yield return new WaitForSeconds(1f);
        }
    }
}
