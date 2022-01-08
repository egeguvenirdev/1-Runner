using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool enter = false;
    public bool exit = false;

    public GameObject[] fallinrocks;

    // Update is called once per frame
    private void Update()
    {
        if(enter == true)
        {
        
        }
    }

    public void TriggerRocks()
    {
        StartCoroutine(DropRocks(10));
    }

    IEnumerator DropRocks(int rockNumber)
    {
        while (enter == true)
        {
            //Instantiate
            yield return new WaitForSeconds(1f);
        }
    }
}
