using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //exit and enter triggers
    public bool playerEnter = false;
    public bool playerExit = false;
    public ExitTrigger exitTrigger;

    //random number variables
    private int randomRock;
    private int randomTransform;
    private Transform rockPosition;
    private static int droneCounter = 0;

    //fallin rocks & drones and their random transforms
    public GameObject[] fallinRocks;
    private GameObject[] drones;
    public GameObject drone;
    public Transform[] droneInstantiateTransforms;
    public Transform[] rockInstantiateTransforms;

    //maze blocks
    public GameObject[] maze;

    //laser gate
    public LaserEnter[] laserEnter;
    public LaserExit[] laserExit;

    //when player has entered the lv
    public void EnterMethod()
    {
        playerEnter = true;

        DroneSpawner();
        StartCoroutine(DropRocks());
    }

    //when player has exit the lv
    public void ExitMethod()
    {
        playerExit = true;
        playerEnter = false;
    }


    //endless lv 
    public void LvMover(int lvCount)
    {
        maze[lvCount].transform.position += new Vector3(0, 0, 1200f);
    }


    //drone spawner method
    private void DroneSpawner()
    {
            for (droneCounter = 0; droneCounter < 4; droneCounter++)
            {
                Instantiate(drone, droneInstantiateTransforms[droneCounter].transform.position, 
                    droneInstantiateTransforms[droneCounter].transform.rotation, gameObject.transform);
            }       
    }


    //if there are no drones, exitgate is opened
    public void SubstractDroneCount()
    {
        droneCounter--;

        if (droneCounter <= 0)
        {
            exitTrigger.OpenGate();
            CloseExitLasers();
        }   
    }

    public void OpenEnterLasers()
    {
        for (int i = 0; i < laserEnter.Length; i++)
        {
            laserEnter[i].GetComponent<LaserEnter>().OpenLaserGate();
        }
    }

    public void CloseEnterLasers()
    {
        for (int i = 0; i < laserEnter.Length; i++)
        {
            laserEnter[i].GetComponent<LaserEnter>().CloseLaserGate();
        }
    }

    public void OpenExitLasers()
    {
        for (int i = 0; i < laserEnter.Length; i++)
        {
            laserExit[i].GetComponent<LaserExit>().OpenLaserGate();
        }
    }

    public void CloseExitLasers()
    {
        for (int i = 0; i < laserEnter.Length; i++)
        {
            laserExit[i].GetComponent<LaserExit>().CloseLaserGate();
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
