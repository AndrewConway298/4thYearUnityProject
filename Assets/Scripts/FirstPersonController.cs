using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FirstPersonController : MonoBehaviour {
    //Movement Variables
    public float movementSpeed = 7.5f;
    public float mouseSensitivity = 5.0f;
    float vertRot = 0;
    public float neckRange = 60.0f;
    public float jumpSpeed = 7.5f;
    //Physics
    float vertVelocity = 0;

	// Use this for initialization
	void Start () {
        Screen.lockCursor = true;
        //StartCoroutine(postRequest("http://localhost:64537/Player"));
        Application.OpenURL("http://localhost:64537/Player?id=4&username=ABC123&score=10000");
    }
	
	// Update is called once per frame
	void Update () {
        CharacterController cc = GetComponent<CharacterController>();

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

    /*IEnumerator postRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");
        form.AddField("Game Name", "Mario Kart");

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.Send();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }*/
}
