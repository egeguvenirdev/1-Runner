using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagement : MonoBehaviour
{
    private float playerHealth = 50f;
    public GameObject death_effect;


    public void PlayerDeath(float playerDamage)
    {
        Instantiate(death_effect, transform.position, Quaternion.identity);

        playerHealth -= playerDamage;

        if (playerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
