using UnityEngine;
using UnityEngine.InputSystem;

public class DemoCameraMovement : MonoBehaviour
{
    public GameObject rearCamera;




    public Camera freeLookCamera;
    private float zoomSpeed = 100f;
    public float horizontalRotation;
    public float verticalRotation;
    public float cameraRotationSpeed;
    private float zoomOutSpeed = 100f;
    public bool isZoomingIn;

    // variable for how fast the rotation will happen
    private float rotationSpeed = 130f;
    private float returnSpeed = 270f;
    private float transformSpeed = 5f;
    private float laptopRotationSpeed = 150f;

    //checks if the user is able to reset center
    public bool isResetCenter = false;

    // making variables for moving up and down, left and right that can later be changed via input.
    public float verticalAngle;
    public float horizontalAngle;
    public float clampAngle;
    public float LookingHorizontalAngle = 90f;

    // checks if player has looked in the rear
    public bool hasSeenRear = false;

    // checks if player is going to go back to center
    public bool goingBackToCenter;

    // checks if player is using the input to looking at rear
    public bool rearInput;

    // checks if its looking left or right
    public bool isLookingRight;
    public bool isLookingLeft;
    public bool isLookingAtLaptop;
    public bool isNotLookingAtLaptop;
    public bool laptopFunction;
    public bool isTurning;
    public bool canUseCamera = false;
    public bool zoomInFunction;
    public bool zoomOutFunction;
    public bool getAxis;

    //checks if it can reset in the middle
    public bool canReset;

    public Transform Target;
    public Transform Original;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isTurning = true;
        canUseCamera = false;
        freeLookCamera = Camera.main;
    }



    void Update()
    {

       



        // moves left or right if the vertical angle is less than 0.1 (basically in the middle)
        if (canUseCamera == false)
        {
            if (Keyboard.current.wKey.wasPressedThisFrame && canReset == true)
            {
                isResetCenter = true;
            }

            if (Mathf.Abs(verticalAngle) < 0.1f)
            {
                if (isTurning == true)
                {
                    if (isLookingRight == false)
                    {
                        if (Keyboard.current.aKey.wasPressedThisFrame)
                        {
                            isLookingLeft = true;
                        }
                    }


                    if (isLookingLeft == false)
                    {
                        if (Keyboard.current.dKey.wasPressedThisFrame)
                        {
                            isLookingRight = true;
                        }
                    }
                }


                if (isLookingRight == false && isLookingLeft == false)
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

        ResetCamera();
        LookingLeftFunction();
        LookingRightFunction();
        LaptopFunction();
        RearCameraFunction();
        FreeLook();
    }


    


    







    void ResetCamera()
    {

        // resets camera to the middle
        if (isResetCenter == true)
        {
            ResetCameraFromSides();
            if (Mathf.Abs(horizontalAngle) < 0.1f)
            {
                isResetCenter = false;

            }

            transform.localRotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
        }
    }



    // resets the position by first seeing the current rotation and moving towards the initial rotation which is 0 with some speed value.
    void ResetCameraFromSides()
    {
        horizontalAngle = Mathf.MoveTowards(horizontalAngle, 0f, returnSpeed * Time.deltaTime);
    }


    void LookingLeftFunction()
    {
        // runs if player is looking left 
        if (isLookingLeft == true)
        {
            // moves the horizontal angle from its current angle to -60 with returnSpeed so it moves smoothly
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, -LookingHorizontalAngle, returnSpeed * Time.deltaTime);

            // if horizontalAngle has met its desired destination than it doesn't need to rotate anymore
            if (horizontalAngle == -LookingHorizontalAngle)
            {
                isLookingLeft = false;
                canReset = true;
            }
            else
            {
                canReset = false;
            }
            // takes the angle and changes it into euler and then using unity rotation system by rotating it with the desired eulerangle which is horizontalAngle.
            transform.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
        }
    }


    void LookingRightFunction()
    {
        // runs if player is looking right 
        if (isLookingRight == true)
        {
            // moves the horizontal angle from its current angle to 60 with returnSpeed so it moves smoothly
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, LookingHorizontalAngle, returnSpeed * Time.deltaTime);

            // if horizontalAngle has met its desired desintation than it doesn't need to rotate anymore
            if (horizontalAngle == LookingHorizontalAngle)
            {
                isLookingRight = false;
                canReset = true;
            }
            else
            {
                canReset = false;
            }
            transform.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
        }
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
        if (isLookingLeft == false && isLookingRight == false)
        {
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

    }

    void LaptopFunction()
    {
        if (isLookingAtLaptop == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, transformSpeed * Time.deltaTime);
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, 30f, laptopRotationSpeed * Time.deltaTime);
            if (transform.position == Target.position && horizontalAngle == 30f)
            {
                isLookingLeft = false;
                isLookingRight = false;
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
        if(horizontalAngle == -LookingHorizontalAngle|| horizontalAngle == LookingHorizontalAngle)
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
              
                freeLookCamera.fieldOfView = Mathf.MoveTowards(freeLookCamera.fieldOfView, 30f, zoomSpeed * Time.deltaTime);
                if(freeLookCamera.fieldOfView == 30f)
                {
                    zoomInFunction = false;
                    isZoomingIn = true;
                    getAxis = true;
                }
            }

            if(zoomOutFunction == true)
            {
                getAxis = false;
                freeLookCamera.fieldOfView = Mathf.MoveTowards(freeLookCamera.fieldOfView, 60f, zoomSpeed * Time.deltaTime);
                if (freeLookCamera.fieldOfView == 60f)
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
