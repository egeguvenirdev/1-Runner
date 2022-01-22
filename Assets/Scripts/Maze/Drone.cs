using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public GameObject droneBlowUp;
    public LevelManager lm;
    private Transform player;
    private float droneCd = 3;
    public float speed = 10f;
    private float droneHealth = 25f;

    private float distance;
    private float followDistance = 30f, lookAtDistance = 80;
    

    private CharacterState characterState;
    private Animator animator;

    public GameObject bullet;
    public Transform firePoint;
    public GameObject shotEffect;
    enum CharacterState
    {
        Idle = 0,
        Shot = 1,
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.gameObject != null)
        {
            FollowPlayer();
        }
    }

    public void GetHit(float hitDamage)
    {
        droneHealth -= hitDamage;

        if(droneHealth <= 0 && gameObject != null)
        {
            Instantiate(droneBlowUp, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(gameObject);
            gameObject.GetComponentInParent<LevelManager>().SubstractDroneCount();
        }
    }

    private void FollowPlayer()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (lookAtDistance >= distance) 
        { 
            transform.LookAt(player.position);

            if (distance >= followDistance && distance <= lookAtDistance-20)
            {
                //transform.Translate(transform.forward * Time.deltaTime * speed);
                transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
                
            }
        }
        if (distance <= followDistance)
        {

            transform.RotateAround(player.position, Vector3.up, Time.deltaTime * speed * Random.Range(2.5f, 4f));
            droneCd -= Time.deltaTime;

            if (droneCd <= 0)
            {
                //Debug.Log(droneCd);

                SetShotAnim();
                Instantiate(bullet, firePoint.position, transform.rotation * Quaternion.Euler(-270, 0, 0));
                Instantiate(shotEffect, transform.position, Quaternion.identity);
                Invoke("SetIdleAnim", 0.25f);
                droneCd = 3f;
            }
        }
 
    }
    private void SetState(CharacterState state)
    {
        characterState = state;
        animator.SetInteger("shot", (int)state);
    }

    public void SetShotAnim()
    {
        SetState(CharacterState.Shot);
    }

    public void SetIdleAnim()
    {
        SetState(CharacterState.Idle);
    }
}
