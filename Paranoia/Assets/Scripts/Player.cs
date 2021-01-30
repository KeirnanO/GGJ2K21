using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected CharacterController controller;
    protected Rigidbody rb;

    Vector3 playerVelocity;

    public float speed;
    public float jumpForce;

    bool grounded;

    protected Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(8, 8, true);

        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground 
        if(controller.isGrounded)
        {
            grounded = true;
            playerVelocity.y = 0;
        }


        //Move
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //velocity += moveDirection.normalized * acceleration * Time.deltaTime;

        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);


        //Rotate
        transform.rotation = Quaternion.Euler(transform.rotation.x, Camera.main.transform.eulerAngles.y, transform.rotation.z);        


        //Get Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            UnCrouch();
        }

        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded)
            {
                grounded = false;
                playerVelocity.y = jumpForce;
                controller.Move(playerVelocity * Time.deltaTime);
            }
        }
    }

    private void FixedUpdate()
    {
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Crouch()
    {
        speed /= 1.5f;

        controller.height = 1;
    }
    void UnCrouch()
    {
        speed *= 1.5f;

        controller.height = 2;
        transform.position += Vector3.up * 0.5f;
    }


}
