using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRotator : MonoBehaviour
{
    public GameObject bulletDestroyParticle;
    private playerManagement player;

    public float speed;

    private void Start()
    {
        player = FindObjectOfType<playerManagement>();
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);
        //transform.Translate(Vector3.down * Time.deltaTime * 50);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Instantiate(bulletDestroyParticle, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            player.PlayerDeath(5f);
        }
    }

}
