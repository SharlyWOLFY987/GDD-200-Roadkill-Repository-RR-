using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    public GameObject rearCamera;


    //art for the camera UI
    public GameObject cameraArt;

    // variables for using freeLook Camera
    public Camera freeLookCamera;
    private float zoomSpeed = 100f;
    public float horizontalRotation;
    public float verticalRotation;
    public float cameraRotationSpeed;
    private float zoomOutSpeed = 100f;
    public bool isZoomingIn;
    public bool zoomInFunction;
    public bool zoomOutFunction;
    public bool canUseCamera = false;
    public bool getAxis;
    public float zoomInFov;
    public float zoomOutFov;
    public float clampAngle;


    // variable for how fast the rotation will happen
    private float rotationSpeed = 130f;
    private float returnSpeed = 270f;
    private float transformSpeed = 5f;
    private float laptopRotationSpeed = 150f;



    // making variables for moving up and down, left and right that can later be changed via input.
    public float verticalAngle;
    public float horizontalAngle;
    public bool lookingLeft;
    public bool lookingRight;
    public bool lookingRightAgain;
    public bool lookingLeftAgain;
    public bool isMoving;
    public bool isTurning;
    public float lookingHorizontalAngle;

    // checks if player has looked in the rear
    public bool hasSeenRear = false;

    // checks if player is going to go back to center
    public bool goingBackToCenter;

    // checks if player is using the input to looking at rear
    public bool rearInput;

    // laptop functions
    public bool isLookingAtLaptop;
    public bool isNotLookingAtLaptop;
    public bool laptopFunction;
    
    
  
    //transforms for looking in laptop and looking out of laptop
    public Transform Target;
    public Transform Original;


    void Start()
    {

        isTurning = true;
        canUseCamera = false;
        freeLookCamera = Camera.main;
        cameraArt.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



    void Update()
    {

       



        // moves left or right if the vertical angle is less than 0.1 (basically in the middle)
        if (canUseCamera == false)
        {

            if (Mathf.Abs(verticalAngle) < 0.1f)
            {
                if (isTurning == true)
                {
                    if (horizontalAngle == 0f)
                    {
                        if (Keyboard.current.dKey.wasPressedThisFrame)
                        {
                            lookingRight = true;
                        }
                        if (Keyboard.current.aKey.wasPressedThisFrame)
                        {
                            lookingLeft = true;
                        }
                    }

                    if(horizontalAngle == -lookingHorizontalAngle)
                    {
                        if (Keyboard.current.dKey.wasPressedThisFrame)
                        {
                            lookingRightAgain = true;
                        }
                    }
                    
                    if(horizontalAngle == lookingHorizontalAngle)
                    {
                        if(Keyboard.current.aKey.wasPressedThisFrame)
                        {
                            lookingLeftAgain = true;
                        }
                    }

                    if(horizontalAngle == 30f)
                    {
                        if (Keyboard.current.dKey.wasPressedThisFrame)
                        {
                            lookingRight = true;
                        }

                        if (Keyboard.current.aKey.wasPressedThisFrame)
                        {
                            lookingLeftAgain = true;
                        }
                    }
                }
                    
                 


                if (isMoving == false)
                {
                    if (Keyboard.current.tabKey.wasPressedThisFrame && laptopFunction == false)
                    {
                        isTurning = false;
                        isLookingAtLaptop = true;
                    }

                    if (Keyboard.current.tabKey.wasPressedThisFrame && laptopFunction == true)
                    {
                        isNotLookingAtLaptop = true;
                    }
                }
            }
      


            // moves up or down if the horizontal angle is less than 0.1 (basically in the middle)
            if (Mathf.Abs(horizontalAngle) < 0.1f)
            {
                if (Keyboard.current.sKey.wasPressedThisFrame && rearInput == false)
                {
                    hasSeenRear = true;
                }
                if (Keyboard.current.sKey.wasPressedThisFrame && rearInput == true)
                {
                    goingBackToCenter = true;
                }

            }
        }



        lookingLeftFunction();
        lookingRightFunction();
        LaptopFunction();
        RearCameraFunction();
        FreeLook();
    }


    


    




    void lookingRightFunction()
    {
       if(lookingRight == true)
        {
            isMoving = true;
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, lookingHorizontalAngle, returnSpeed * Time.deltaTime);
            if(horizontalAngle == lookingHorizontalAngle)
            {
                lookingRight = false;
                isMoving = false;
            }
       }

       if(lookingRightAgain == true)
        {
            isMoving = true;
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, 0f, returnSpeed * Time.deltaTime);
            if(horizontalAngle == 0f)
            {
                lookingRightAgain = false;
                isMoving = false;
            }
        }

        transform.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
    }

    void lookingLeftFunction()
    {
        if(lookingLeft == true)
        {
            isMoving = true;
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, -lookingHorizontalAngle, returnSpeed * Time.deltaTime);
            if(horizontalAngle == -lookingHorizontalAngle)
            {
                lookingLeft = false;
                isMoving = false;
            }
        }

        if (lookingLeftAgain == true)
        {
            isMoving = true;
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, 0f, returnSpeed * Time.deltaTime);
            if(horizontalAngle == 0f)
            {
                isMoving = false;
                lookingLeftAgain = false;
            }
        }

        transform.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
    }


  


    void RearCameraFunction()
    {

        // checks if the player has clicked s and if it did it rotates the camera to the rear
        if (hasSeenRear == true)
        {
            verticalAngle = Mathf.MoveTowards(verticalAngle, -18f, rotationSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(verticalAngle, 0f, 0f);

            if (verticalAngle == -18f)
            {
                rearCamera.SetActive(true);
                hasSeenRear = false;
                rearInput = true;
            }

        }

        //checks if the player has clicked s while its looking at rear and if it is then it rotates back to the center.
        if (goingBackToCenter == true)
        {
            rearCamera.SetActive(false);
            verticalAngle = Mathf.MoveTowards(verticalAngle, 0f, rotationSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(verticalAngle, 0f, 0f);
            if (verticalAngle == 0f)
            {

                goingBackToCenter = false;
                rearInput = false;
            }

        }
    }

    void LaptopFunction()
    {
        if (isLookingAtLaptop == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, transformSpeed * Time.deltaTime);
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, 30f, laptopRotationSpeed * Time.deltaTime);
            if (transform.position == Target.position && horizontalAngle == 30f)
            {
                isTurning = false;
                isLookingAtLaptop = false;
                laptopFunction = true;
            }
            transform.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
        }

        if (isNotLookingAtLaptop == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Original.position, transformSpeed * Time.deltaTime);

            if (transform.position == Original.position)
            {
                isNotLookingAtLaptop = false;
                laptopFunction = false;
                isTurning = true;

            }
        }
    }


    void FreeLook()
    {
        if(horizontalAngle == -lookingHorizontalAngle || horizontalAngle == lookingHorizontalAngle || horizontalAngle == 0f)
        {
            if(isZoomingIn == false)
            {
                if (Keyboard.current.shiftKey.wasPressedThisFrame)
                {
                    canUseCamera = true;
                    zoomInFunction = true;
                }
            }
            
            if(isZoomingIn == true)
            {
                if (Keyboard.current.shiftKey.wasPressedThisFrame)
                {
                    zoomOutFunction = true;
                }
            }
           

            if(zoomInFunction == true)
            {
              
                freeLookCamera.fieldOfView = Mathf.MoveTowards(freeLookCamera.fieldOfView, zoomInFov, zoomSpeed * Time.deltaTime);
                if(freeLookCamera.fieldOfView == zoomInFov)
                {
                    cameraArt.SetActive(true);
                    zoomInFunction = false;
                    isZoomingIn = true;
                    getAxis = true;
                }
            }

            if(zoomOutFunction == true)
            {
                cameraArt.SetActive(false);
                getAxis = false;
                freeLookCamera.fieldOfView = Mathf.MoveTowards(freeLookCamera.fieldOfView, zoomOutFov, zoomSpeed * Time.deltaTime);
                if (freeLookCamera.fieldOfView == zoomOutFov)
                {
                    zoomOutFunction = false;
                    isZoomingIn = false;
                    canUseCamera = false;         
                }
                horizontalRotation = Mathf.MoveTowards(horizontalRotation, 0f, zoomOutSpeed * Time.deltaTime);
                verticalRotation = Mathf.MoveTowards(verticalRotation, 0f, zoomOutSpeed * Time.deltaTime);
                freeLookCamera.transform.localRotation = Quaternion.Euler(-verticalRotation, horizontalRotation, 0f);

            }

            if (getAxis == true)
            {
                horizontalRotation += Input.GetAxis("Mouse X") * cameraRotationSpeed;
                verticalRotation += Input.GetAxis("Mouse Y") * cameraRotationSpeed;
                horizontalRotation = Mathf.Clamp(horizontalRotation, -clampAngle, clampAngle);
                verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);
                freeLookCamera.transform.localRotation = Quaternion.Euler(-verticalRotation, horizontalRotation, 0f);
            }
           
        }
    }




   



}
