using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    protected CharacterController controller;
    protected Rigidbody rb;

    AudioSource audioSource;

    Vector3 playerVelocity;

    public float speed;
    public float jumpForce;

    bool grounded;

    protected Vector3 moveDirection = Vector3.zero;


    public AudioClip[] grassClips;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Physics.IgnoreLayerCollision(8, 8, true);

        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(Walking());
    }

    // Update is called once per frame
    void Update()
    {

        //Ground 
        if(controller.isGrounded)
        {
            if (!grounded)
            {
                grounded = true;
 
                int ran = Random.Range(0, grassClips.Length);
                audioSource.PlayOneShot(grassClips[ran]);
            }
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

    IEnumerator Walking()
    {
        float time = 0;

        while (true)
        {
            while (moveDirection.magnitude > 0 && grounded)
            {
                //Value for how fast walking
                float timeToStep = 1.5f / moveDirection.magnitude;

                //Play oneshot based on value'
                if (time > timeToStep)
                {
                    int ran = Random.Range(0, grassClips.Length);
                    audioSource.PlayOneShot(grassClips[ran]);

                    time = 0;
                }

                time += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForEndOfFrame();
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
