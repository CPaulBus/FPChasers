using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController cont;
    private Animator charAnim;

    public float speed = 12f;

    public float mouseSensitivity = 50f;

    float xRot = 0f;

    public float mouseY;
    public float mouseX;
    public float jumpHeight = 3f;

    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    private void Awake()
    {
        cont = this.GetComponent<CharacterController>();
        charAnim= this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementCont();
        RotationCont();
    }

    void MovementCont()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0)
        {
            charAnim.SetFloat("x", x);
        }

        if (z != 0)
        {
            charAnim.SetFloat("z", z);
        }

        Vector3 move = transform.right * x + transform.forward * z;
        cont.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            charAnim.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);            
        }

        velocity.y += gravity * Time.deltaTime;
        cont.Move(velocity * Time.deltaTime);


    }
    void RotationCont()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        this.transform.Rotate(Vector3.up * mouseX);
    }
}
