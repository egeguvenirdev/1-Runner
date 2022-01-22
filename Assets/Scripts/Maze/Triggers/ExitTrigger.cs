using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public LevelManager lm;
    public EnterTrigger et;
    private GameObject[] liveEnemies;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
        col.isTrigger = false;
    }

    /*private void FixedUpdate()
    {
        liveEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(liveEnemies.Length == 0)
        {
            Debug.Log("kapi acik");
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //Invoke("TriggerOff", 1f);
        lm.ExitMethod();
        et.TriggerOn();
    }

    public void OpenGate()
    {
        col.isTrigger = true;
    }
}
