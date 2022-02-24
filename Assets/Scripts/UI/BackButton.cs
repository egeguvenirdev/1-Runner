using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public GameObject openUI, closeUI;

    public void SwitchUIMenu()
    {
        closeUI.SetActive(false);
        openUI.SetActive(true);
    }


}
