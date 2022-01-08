using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRotator : MonoBehaviour
{
    public float speed;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);
    }
}
