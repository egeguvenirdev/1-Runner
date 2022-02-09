using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserExit : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask laser, player;
    public playerManagement playerManagement;
    //public bool gateChecker = true;

    private bool gateOpen = true;

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gateOpen)
        {
            //laser renderer
            if (Physics.Raycast(transform.position, transform.forward, out hit, 200, laser))
            {
                lineRenderer.enabled = true;

                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
                lineRenderer.startWidth = 0.5f + Mathf.Sin(Time.time) / 1.1f;
            }

            //player hit
            if (Physics.Raycast(transform.position, transform.forward, out hit, 40.85f, player))
            {
                //hit.transform.gameObject.GetComponent<playerManagement>().PlayerDeath(5);
                playerManagement.PlayerDeath(50);
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    public void OpenLaserGate()
    {
        gateOpen = true;
    }

    public void CloseLaserGate()
    {
        gateOpen = false;
    }
}
