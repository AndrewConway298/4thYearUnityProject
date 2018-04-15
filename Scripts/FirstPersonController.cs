//X00121654 Andrew Conway 4th Year Project
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(CharacterController))]                             //Checks for character controller
public class FirstPersonController : MonoBehaviour {
    //Movement Variables
    public float movementSpeed = 7.5f;
    public float mouseSensitivity = 5.0f;
    float vertRot = 0;
    public float neckRange = 60.0f;
    public float jumpSpeed = 7.5f;
    //Physics
    float vertVelocity = 0;
    //Check
    CharacterController cc;

	// Use this for initialization
	void Start () {
        Screen.lockCursor = true;
        cc = GetComponent<CharacterController>();
        Debug.Log("Starting");
    }

	// Update is called once per frame
	void Update () {
        //Rotation(Mouse)
        float rotLR = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLR, 0);
        vertRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        vertRot = Mathf.Clamp(vertRot, -neckRange, neckRange);
        Camera.main.transform.localRotation = Quaternion.Euler(vertRot, 0, 0);

        //Movement
        //Forward/Back + Left/Right
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        //Sprint
        if (Input.GetButtonDown("Fire3"))
        {
            movementSpeed = movementSpeed * 2f;
            forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
            sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            movementSpeed = movementSpeed / 2f;
            forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
            sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        }
        //Jumping
        vertVelocity += Physics.gravity.y * Time.deltaTime;

        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            vertVelocity = jumpSpeed;
        }
        //Speed

        Vector3 speed = new Vector3(sideSpeed, vertVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);

    }
}
