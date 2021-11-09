using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float walkSpeed, runSpeed;
    private float speed;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private bool onGround;

    private void Update() {
        onGround = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        speed = Input.GetButton("Fire3") ? runSpeed : walkSpeed;

        if (onGround && velocity.y < 0) velocity.y = -2f;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        if (onGround && Input.GetButtonDown("Jump")) {
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
