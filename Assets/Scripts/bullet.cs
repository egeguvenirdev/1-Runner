using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //bullet
    private float speed = 150;
    private float lifeTime = 5f;

    private playerManagement player;

    private void Start()
    {
        player = FindObjectOfType<playerManagement>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.layer == 9)
        {
            player.PlayerDeath(25);
        }

        if (collision.gameObject.layer == 10)
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Drone>().GetHit(5);
        }

    }

}
