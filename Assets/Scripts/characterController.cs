using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    //player movement
    private CharacterController controller;
    public float speed;

    //jump and gravity
    private Vector3 velocity;
    public float gravity;
    private bool onGround;
    public float jumpVelocity;
    public float groundedGravity;

    public Transform groundChecker;
    private float groundCheckerRadius = 0.2f;
    public LayerMask obstacleLayer;

    //camera movement
    private float xRotation = 0f;
    public float mouseSensivity = 100f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        PlayerMovement();
        CameraMovement();
        JumpAndGravity();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift) && onGround)
        {
            speed = 40;
        }
        else
        {
            speed = 20;
        }

        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;
        controller.Move(moveVelocity);

    }

    private void JumpAndGravity()
    {
        onGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);
        //Debug.Log(onGround);

        if (!onGround)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        else
        {
            velocity.y = -(groundedGravity);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Debug.Log(onGround);
            velocity.y = jumpVelocity;
        }

        controller.Move(velocity);
    }

    private void CameraMovement()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity, 0);

        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

}
