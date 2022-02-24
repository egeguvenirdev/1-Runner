using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagement : MonoBehaviour
{

    //ui
    public GameObject healtBarUi;
    public GameObject gameoverUI;
    public GameObject backButtonUI;
    public GameObject crosshair;
    public HealthBar healthBar;
    private bool isPaused = false;

    //player
    public GameObject gun;
    public int playerHealth; 
    private int playerCurrentHealth;
    public GameObject death_effect;
    public FirstPersonLook firstPersonLook;


    private void Start()
    {
        playerCurrentHealth = playerHealth;
        healthBar.SetMaxHealth(playerHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                isPaused = true;
                PauseMenu();
            }
            else
            {
                isPaused = false;
                ResumeMenu();
            }
            
        }
            
    }


    public void PlayerDeath(int playerTakeDamage)
    {
        //blood loss effect
        Instantiate(death_effect, transform.position, Quaternion.identity);

        playerCurrentHealth -= playerTakeDamage;
        healthBar.SetHealth(playerCurrentHealth);

        //death
        if (playerCurrentHealth <= 0 && gameObject != null)
        {
            //lock player movements
            GetComponent<Jump>().enabled = false;
            GetComponent<FirstPersonMovement>().enabled = false;
            GetComponent<Crouch>().enabled = false;
            //gameObject.transform.GetChild(0).gameObject.GetComponent<FirstPersonLook>().enabled = false;
            firstPersonLook.enabled = false;

            //unluck cursor and gun
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gun.SetActive(false);

            //remove the crosshair and healthbar
            crosshair.SetActive(false);
            healtBarUi.SetActive(false);

            //death ui menu
            gameoverUI.SetActive(true);

        }
    }

    private void PauseMenu()
    {
        gameoverUI.SetActive(true);
        backButtonUI.SetActive(true);

        Time.timeScale = 0;

        firstPersonLook.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void ResumeMenu()
    {
        gameoverUI.SetActive(false);
        backButtonUI.SetActive(false);

        Time.timeScale = 1;

        firstPersonLook.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResumeButton()
    {
        gameoverUI.SetActive(false);
        backButtonUI.SetActive(false);

        Time.timeScale = 1;

        firstPersonLook.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
