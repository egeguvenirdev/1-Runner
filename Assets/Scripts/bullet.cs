using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //bullet
    private float speed = 150;
    private float lifeTime = 5f;
    void Update()
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
        if (collision.gameObject.layer == 9)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }

    }
}
