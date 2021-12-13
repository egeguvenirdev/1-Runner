using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBox : MonoBehaviour
{
    public Transform checker;
    public LayerMask playerMask;
    public float radius;
    private bool boxDestroyer = false;
    private Vector3 scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
    public GameObject jumpboxBlowUp;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Physics.CheckBox(checker.position, new Vector3(radius, 1, radius), Quaternion.identity, playerMask))
        {
            boxDestroyer = true;
        }
        /*else
        {
            boxDestroyer = false;
        }*/

        if (boxDestroyer)
        {
            BoxSize();
        }
    }

    private void BoxSize()
    {
        if (this.gameObject.transform.localScale.y > 1.5f)
        {
            this.gameObject.transform.localScale += scaleChange;
        }
        else
        {
            Destroy(this.gameObject);
            Instantiate(jumpboxBlowUp, transform.position, Quaternion.identity);
        }
    }
}
