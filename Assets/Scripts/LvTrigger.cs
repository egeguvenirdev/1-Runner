using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvTrigger : MonoBehaviour
{
    public LevelManager lm;
    public bool enterTrigger;

    private void OnTriggerEnter(Collider other)
    {

        if (enterTrigger)
        {
            Invoke("TriggerOff", 1f);
            lm.enter = true;
            lm.TriggerRocks();
        }

        else
        {
            Invoke("TriggerOff", 1f);
            lm.exit = true;
        }
    }

    private void TriggerOff()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
    }
}
