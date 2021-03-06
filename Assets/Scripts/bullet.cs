using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //bullet
    public int bulletDamage;
    public float speed = 250;
    private float lifeTime = 5f;

    private playerManagement player;

    public GameObject bulletDestroyParticle;

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
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Lava")
        {
            Instantiate(bulletDestroyParticle, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            player.PlayerDeath(bulletDamage);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(bulletDestroyParticle, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Drone>().GetHit(5);
        }

    }

}
