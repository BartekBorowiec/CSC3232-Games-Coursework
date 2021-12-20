using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform PlayerBody;

    public float mouseSensitivity = 350; 

    float xRotation = 0f; 

    //locks the cursor at the start so you cant see it.
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked; 
    }
    //function to change the sens from the settings
    public void GetSensitivity(float newSensitivity){
        mouseSensitivity = newSensitivity;

    }

    void Update()
    {
        // implements the mouse sens
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //locks the camera so you cant go vertically around fully.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        //rotates the players body with the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX); 

        
    }
}
