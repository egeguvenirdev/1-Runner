using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    private playerManagement player;

    private void Start()
    {
        player = FindObjectOfType<playerManagement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter bullet");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("entered the lava area");
            InvokeRepeating("PlayerLavaHit", 0.1f, 0.5f);
        }
    }
    /*private void OnCollisionStay(Collision collision)
    {
        Debug.Log("stay bullet");
        if (collision.gameObject.tag == "Player")
        {
            player.PlayerDeath(5f);
            Debug.Log("stay");
        }
    }*/

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit bullet");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("lefted the lava area");
            CancelInvoke();
        }
    }

    /*void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            InvokeRepeating("PlayerLavaHit", 2, 1);
            Debug.Log("lava 2");
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            CancelInvoke();
        }
    }*/

    private void PlayerLavaHit()
    {
        player.PlayerDeath(5f);
        Debug.Log(player.playerHealth);
    }
}
