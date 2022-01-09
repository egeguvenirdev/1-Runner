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
            lm.EnterMethod();
        }

        else
        {
            Invoke("TriggerOff", 1f);
            lm.ExitMethod();
        }
    }

    private void TriggerOff()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
    }
}
