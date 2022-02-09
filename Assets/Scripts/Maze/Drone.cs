using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drone : MonoBehaviour
{

    //objects
    public GameObject droneBlowUp;
    private Transform player;
    public HealthBar healthBar;

    //drone stats
    private float droneCd = 3;
    public float speed = 10f;
    public int droneHealth; 
    private int droneCurrentHealth;

    //player follow
    private float distance;
    private float followDistance = 30f, lookAtDistance = 80;
    
    //animation
    private CharacterState characterState;
    private Animator animator;

    //drone shooting
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

        droneCurrentHealth = droneHealth;
        healthBar.SetMaxHealth(droneHealth);
    }

    void Update()
    {
        if (player.gameObject != null)
        {
            FollowPlayer();
        }
    }

    public void GetHit(int droneTakeDamage)
    {
        droneCurrentHealth -= droneTakeDamage;
        healthBar.SetHealth(droneCurrentHealth);

        if (droneCurrentHealth <= 0 && gameObject != null)
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
