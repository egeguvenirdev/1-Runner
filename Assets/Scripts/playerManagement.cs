using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagement : MonoBehaviour
{
    //private bool playerAlive = true;
    public GameObject death_effect;
    public void Death(bool playerCheck)
    {
        if (playerCheck == false)
        {
            Instantiate(death_effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            //playerAlive = false;
        }
    }
}
