using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    private FirstPersonLook cam;

    private void Awake()
    {
        //GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.GetComponent<FirstPersonLook>().sensitivity = PlayerPrefs.GetFloat("MouseSens", 2);
        cam = FindObjectOfType<FirstPersonLook>();
        cam.sensitivity = PlayerPrefs.GetFloat("MouseSens", 2);
    }
}
