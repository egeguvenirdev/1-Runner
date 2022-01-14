using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagement : MonoBehaviour
{
    public float playerHealth = 50f;
    public GameObject death_effect;


    public void PlayerDeath(float playerDamage)
    {
        //blood loss effect
        Instantiate(death_effect, transform.position, Quaternion.identity);

        playerHealth -= playerDamage;


        //death
        if (playerHealth <= 0 && gameObject != null)
        {
            //lock player movements
            GetComponent<Jump>().enabled = false;
            GetComponent<FirstPersonMovement>().enabled = false;
            GetComponent<Crouch>().enabled = false;

            //unluck cursor for ui
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }
}
