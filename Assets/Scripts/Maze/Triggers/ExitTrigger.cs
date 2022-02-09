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

    private void OnTriggerEnter(Collider other)
    {
        lm.ExitMethod();
        et.TriggerOn();
        //lm.CloseAllLasers();
        lm.OpenExitLasers();
    }

    public void OpenGate()
    {
        col.isTrigger = true;
    }
}
