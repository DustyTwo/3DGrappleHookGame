using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 15f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float gravityScale = -9.8f;

    [SerializeField] float grappleRange = 15f;
    [SerializeField] LayerMask grappleLayerMask;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.5f;
    [SerializeField] LayerMask groundLayerMask;

    Camera playerCamera;

    bool grounded;
    bool grappled;

    CharacterController controller;

    float moveX;
    float moveZ;

    Vector3 velocity;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;
    }

    void Update()
    {
        //ground check
        grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayerMask);
        //jumping
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
        }
        else if(grounded && velocity.y < 0f)
        {
            velocity.y = -3f;
        }
        else
        {
            //gravity
            velocity.y += gravityScale * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        //input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //movement (likadant för mark som i luften atm)
        Vector3 movementDirection = transform.right * moveX + transform.forward * moveZ;
        controller.Move(movementDirection * movementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0) && !grappled)
        {
            print("meme");
        }

    }
}
