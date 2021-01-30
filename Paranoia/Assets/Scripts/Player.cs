using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected CharacterController controller;
    public float speed;

    protected Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //velocity += moveDirection.normalized * acceleration * Time.deltaTime;

        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);

        transform.rotation = Quaternion.Euler(transform.rotation.x, Camera.main.transform.eulerAngles.y, transform.rotation.z);
        //Quaternion newRotation = new Quaternion(transform.rotation.x, Camera.main.transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //transform.rotation = newRotation;
    }
}
