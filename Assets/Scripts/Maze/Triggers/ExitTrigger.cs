using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public LevelManager lm;
    public EnterTrigger et;
    private GameObject[] liveEnemies;

    private void Start()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
    }

    private void FixedUpdate()
    {
        liveEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(liveEnemies.Length > 0)
        {
            Debug.Log("kapi kapali");
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
        else
        {
            Debug.Log("kapi acik");
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
        /*foreach (GameObject enemy in liveEnemies)
        {
            if(enemy == null)
            {
                Destroy(enemy);
            }
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        //Invoke("TriggerOff", 1f);
        lm.ExitMethod();
        et.TriggerOn();
    }
}
