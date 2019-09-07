using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
//    private PlayerAnimation playerAnimation;
    private Rigidbody myBody;

    public float walkSpeed = 2f;
    public float zSpeed = 1.5f;

    private float rotationY = -90f;
    private float rotationSpeed = 15f;

    void Awake()
    {
//        playerAnimation = GetComponentInChildren < PlayerAnimation();
        myBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-zSpeed)
        );
    }

    void RotatePlayer()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotationY), 0f);
        } else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
        }
    }
}