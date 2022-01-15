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
        if (collision.gameObject.tag == "Player")
        {
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
        if (collision.gameObject.tag == "Player")
        {
            CancelInvoke();
        }
    }

    private void PlayerLavaHit()
    {
        player.PlayerDeath(5f);
        //Debug.Log(player.playerHealth);
    }
}
