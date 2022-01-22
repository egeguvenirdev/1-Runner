using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagement : MonoBehaviour
{

    //ui
    public GameObject healtBarUi;
    public GameObject crosshair;

    //player
    public GameObject gun;
    public HealthBar healtBar;
    public int playerHealth, playerCurrentHealth;
    public GameObject death_effect;


    private void Start()
    {
        playerCurrentHealth = playerHealth;
        healtBar.SetMaxHealth(playerHealth);
    }

    public void PlayerDeath(int playerTakeDamage)
    {
        //blood loss effect
        Instantiate(death_effect, transform.position, Quaternion.identity);

        playerCurrentHealth -= playerTakeDamage;
        healtBar.SetHealth(playerCurrentHealth);

        //death
        if (playerCurrentHealth <= 0 && gameObject != null)
        {
            //lock player movements
            GetComponent<Jump>().enabled = false;
            GetComponent<FirstPersonMovement>().enabled = false;
            GetComponent<Crouch>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.GetComponent<FirstPersonLook>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.GetComponent<FirstPersonLook>().enabled = false;

            //unluck cursor and gun
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gun.SetActive(false);

            //remove the crosshair and healthbar
            crosshair.SetActive(false);
            healtBarUi.SetActive(false);

        }
    }
}
