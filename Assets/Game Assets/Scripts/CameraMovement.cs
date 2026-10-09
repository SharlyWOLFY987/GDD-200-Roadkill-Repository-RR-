using UnityEngine;


public class CameraMovement : MonoBehaviour
{


    // variable for how fast the rotation will happen
    private float rotationSpeed = 130f;
    private float returnSpeed = 270f;
    public Transform target;
    public Transform center;
    public bool isLookAtRear;


    // sets the default variable for the Y rotation
    public float horizontalAngle = 0f;
    public float verticalAngle = 0f;


    void Start()
    {

    }


    void Update()
    {




        //if A key is held then the camera will rotate to the left multiplied by its rotation variable  
        // cameraAngle will be changing continuously to negative value
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && isLookAtRear == false)
        {
            horizontalAngle -= rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
            horizontalAngle = Mathf.Clamp(horizontalAngle, -90f, 90f);


        }

        //if D key is held then the camera will rotate to the right multiplied by its rotation variable
        // cameraAngle will be chaning continouosly to positive value
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && isLookAtRear == false)
        {
            horizontalAngle += rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
            horizontalAngle = Mathf.Clamp(horizontalAngle, -90f, 90f);

        }

        // limits the cameraAngle from reaching more than -90 and 90 to limit rotation


        // if W  or up arrow is pressed then the camera will return to its original rotation state
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && isLookAtRear == false)
        {
            ResetCameraFromSides();
        }

        if (Input.GetKey(KeyCode.S))
        {
            verticalAngle = Mathf.MoveTowards(verticalAngle, -25f, returnSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(verticalAngle, 0f, 0f);

        }
        if (!Input.GetKey(KeyCode.S))
        {
            verticalAngle = Mathf.MoveTowards(verticalAngle, 0f, returnSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
        }


    }





    // resets the position by first seeing the current rotation and moving towards the initial rotation which is 0 with some speed value.
    void ResetCameraFromSides()
    {
        horizontalAngle = Mathf.MoveTowards(horizontalAngle, 0f, returnSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
    }

    void lookRear()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, returnSpeed * Time.deltaTime);
    }

    void ResetToCenter()
    {
        Quaternion resetRotation = Quaternion.LookRotation(center.position - target.position);

    }







}
