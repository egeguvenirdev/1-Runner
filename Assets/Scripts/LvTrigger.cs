using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvTrigger : MonoBehaviour
{
    public LevelManager lm;
    public bool enterTrigger;
    private static int firstLvCount = 0;
    private static int secondLvCount = 0;

    private void OnTriggerEnter(Collider other)
    {

        if (enterTrigger)
        {
            //closing the enter gate
            //Invoke("TriggerOff", 1f);

            //it will istantiate the fallin rocks and drones
            lm.EnterMethod();

            //first 1 and 2. lvs check, do nothing
            if(firstLvCount <= 1)
            {
                firstLvCount++;
            }
            //inf loop
            else
            {
                lm.LvMover(secondLvCount);
                gameObject.GetComponent<Collider>().isTrigger = true;
                secondLvCount++;
                if (secondLvCount == 4)
                {
                    secondLvCount = 0;
                }
            }           
        }

        else
        {
            //Invoke("TriggerOff", 1f);
            lm.ExitMethod();
        }
    }

    private void TriggerOff()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
    }
}
