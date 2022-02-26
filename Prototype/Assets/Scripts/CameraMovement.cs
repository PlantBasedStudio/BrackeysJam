using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // mouse sensitivity
    public float mouseSensitivity = 100f;



    public static bool canMove = true;
    // reference to our player
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        // Hide the cursor (press exit to go show)
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {

      
        // Mouse movement axis float
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
