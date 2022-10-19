using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController control;
    public float moveSpeed = 15f;
    public float jumpHeight = 2f;

    public float gravity = -19.62f;

    public Transform grounded;
    public float groundSphereRadius = 0.2f;
    public LayerMask groundMask;


    Vector3 currentVelocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.CheckSphere(grounded.position, groundSphereRadius, groundMask))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }

        if(isGrounded && currentVelocity.y < 0)
        {
            currentVelocity.y = -1.5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        control.Move(move * moveSpeed * Time.deltaTime);
        currentVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && Input.GetButton("Jump"))
        {
            currentVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        control.Move(currentVelocity * Time.deltaTime);
    }
}
