using UnityEngine;


public class CameraMovement : MonoBehaviour
{
  

    // variable for how fast the rotation will happen
    private float rotationSpeed = 130f;
    private float returnSpeed = 270f;


    // sets the default variable for the Y rotation
    public float cameraAngle = 0f;


    void Start()
    {
       
    }


    void Update()
    {



        //if A key is held then the camera will rotate to the left multiplied by its rotation variable  
        // cameraAngle will be changing continuously to negative value
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            cameraAngle -= rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0f, cameraAngle, 0f);

        }

        //if D key is held then the camera will rotate to the right multiplied by its rotation variable
        // cameraAngle will be chaning continouosly to positive value
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            cameraAngle += rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0f, cameraAngle, 0f);

        }

        // limits the cameraAngle from reaching more than -90 and 90 to limit rotation
        cameraAngle = Mathf.Clamp(cameraAngle, -90f, 90f);

        // if W  or up arrow is pressed then the camera will return to its original rotation state
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            ResetCameraFromSides();
        }
        // Actual rotation mechanism that rotates based on the changes done to our cameraAngle variable by pressing d or a
        

      



        // resets the position by first seeing the current rotation and moving towards the initial rotation which is 0 with some speed value.
        void ResetCameraFromSides()
        {
            cameraAngle = Mathf.MoveTowards(cameraAngle, 0f, returnSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0f, cameraAngle, 0f);
          
           
        }

       



    }

}
