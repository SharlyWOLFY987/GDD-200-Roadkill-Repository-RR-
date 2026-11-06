using UnityEngine;  
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PhotoCamera : MonoBehaviour
{
    public float horizontalRotation;
    public float verticalRotation;
    public float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.rotation = Quaternion.Euler(-verticalRotation, horizontalRotation, 0f);
            horizontalRotation += Input.GetAxis("Mouse X") * rotationSpeed;
            verticalRotation += Input.GetAxis("Mouse Y") * rotationSpeed;
        }

    }
}
