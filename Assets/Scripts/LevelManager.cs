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
    private GameObject rockPosition;

    //fallin rocks and their random transforms
    public GameObject[] fallinRocks;
    public GameObject[] fallinRocksTransforms;

    // Update is called once per frame
    /*private void Update()
    {
        if(enter == true)
        {
        
        }
    }*/

    public void TriggerRocks()
    {
        StartCoroutine(DropRocks(10));
    }

    IEnumerator DropRocks(int rockNumber)
    {
        while (enter == true)
        {
            randomRock = Random.Range(0, (fallinRocks.Length));

            randomTransform = Random.Range(0, (fallinRocksTransforms.Length));

            rockPosition = fallinRocksTransforms[randomTransform];

            Debug.Log("Coroutine instantiate");
            Instantiate(fallinRocks[randomRock], rockPosition.transform.position, rockPosition.transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
