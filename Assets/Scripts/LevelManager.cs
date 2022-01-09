using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //exit and enter triggers
    public bool enter = false;
    public bool exit = false;

    //random number variables
    private int randomRock;
    private int randomTransform;
    private Transform rockPosition;

    //fallin rocks and their random transforms
    public GameObject[] fallinRocks;
    public Transform[] rockInstantiateTransforms;

    // Update is called once per frame
    /*private void Update()
    {
        if(enter == true)
        {
        
        }
    }*/

    public void EnterMethod()
    {
        enter = true;
        StartCoroutine(DropRocks());
    }

    public void ExitMethod()
    {
        exit = true;
    }

    IEnumerator DropRocks()
    {
        while (enter == true)
        {
            randomRock = Random.Range(0, (fallinRocks.Length));

            randomTransform = Random.Range(0, (rockInstantiateTransforms.Length));

            rockPosition = rockInstantiateTransforms[randomTransform];

            Debug.Log("Coroutine instantiate");
            Instantiate(fallinRocks[randomRock], rockPosition.transform.position, rockPosition.transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
