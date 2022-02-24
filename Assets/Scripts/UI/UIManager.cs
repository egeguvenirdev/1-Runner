using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameoverUI;
    public GameObject backButtonUI;

    public FirstPersonLook firstPersonLook;

    private bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
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
    private void PauseMenu()
    {
        gameoverUI.SetActive(true);
        backButtonUI.SetActive(true);

        Time.timeScale = 0;

        firstPersonLook.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeMenu()
    {
        gameoverUI.SetActive(false);
        backButtonUI.SetActive(false);

        isPaused = false;

        //isPaused = false;
        Time.timeScale = 1;

        firstPersonLook.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
