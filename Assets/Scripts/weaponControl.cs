using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class weaponControl : MonoBehaviour
{

    private CharacterState characterState;
    private Animator animator;
    private playerManagement player;

    enum CharacterState
    {
        Idle = 0,
        Shot = 1,
    }


    //fire
    public GameObject bullet;
    public Transform firePoint;

    //audio
    public AudioClip gunShot;

    //cd
    private float coolDown;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<playerManagement>();
    }
    void Update()
    {
        //cd
        coolDown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && coolDown <=0)
        {
            //create bullet - fire
            //Debug.Log(transform.rotation);
            Instantiate(bullet, firePoint.position, transform.rotation * Quaternion.Euler(90.2f, 0, -0.55f));
            coolDown = 0.3f;

            //Shot audio
            player.GetComponent<AudioSource>().PlayOneShot(gunShot);

            //Animation
            SetShotAnim();
            //Invoke("SetIdleAnim", 0.25f);

        }
    }

    public void SetShotAnim()
    {
        SetState(CharacterState.Shot);
    }

    public void SetIdleAnim()
    {
        SetState(CharacterState.Idle);
    }

    private void SetState(CharacterState state)
    {
        characterState = state;
        animator.SetInteger("shot", (int)state);
    }
}
