using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle, player;

    // Update is called once per frame
    void FixedUpdate()
    {   
        //laser & renderer 
        if (Physics.Raycast(transform.position, transform.forward, out hit, 40.85f, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;

            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
            GetComponent<LineRenderer>().startWidth = 0.25f + Mathf.Sin(Time.time) / 10; 
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false; 
        }

        //player hit
        if(Physics.Raycast(transform.position, transform.forward, out hit, 40.85f, player))
        {
            //Destroy(hit.transform.gameObject);
            hit.transform.gameObject.GetComponent<playerManagement>().PlayerDeath(5);
        }

    }
}
