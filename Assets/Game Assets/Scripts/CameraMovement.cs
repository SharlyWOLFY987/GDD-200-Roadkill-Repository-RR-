using UnityEngine;


public class CameraMovement : MonoBehaviour
{
  

    // variable for how fast the rotation will happen
    private float rotationSpeed = 130f;
    public float rearViewSpeed = 900f;
    private float returnSpeed = 270f;
    public Transform target;
    public bool isResetCenter = false;
    public Transform center;
    public float verticalAngle;
    public float horizontalAngle;
    public bool hasSeenRear = false;
    public bool goingBackToCenter;
    public bool rearInput;
    public bool isLookingRight;
    public bool isLookingLeft;
    public bool canReset;
   





    void Start()
    {
        
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W) && canReset == true)
        {
            isResetCenter = true;
        }


 

            if (Mathf.Abs(verticalAngle) < 0.1f)
            {

                if (Input.GetKey(KeyCode.A))
                {
                  isLookingLeft = true;
                }

                if(Input.GetKey(KeyCode.D))
                {
                 isLookingRight = true;
                }
               
            }


            if (Mathf.Abs(horizontalAngle) <0.1f)
            {
                if (Input.GetKeyDown(KeyCode.S) && rearInput == false)
                {
                    hasSeenRear = true;
                }
                if(Input.GetKeyDown(KeyCode.S) && rearInput == true)
                {
                    goingBackToCenter = true;
                }

            
            }


         
         if(isLookingLeft == true)
         {
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, -60, returnSpeed * Time.deltaTime);

            if (horizontalAngle == -60f)
            {
                isLookingLeft = false;
                canReset = true;
            }
            else
            {
                canReset = false;
            }

            transform.localRotation = Quaternion.Euler(0f, horizontalAngle,0f);
         }

        if(isLookingRight == true)
        {
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, 60, returnSpeed * Time.deltaTime);
            if (horizontalAngle == 60f)
            {
                isLookingRight = false;
                canReset = true;
            }
            else
            {
                canReset = false;
            }
            transform.localRotation = Quaternion.Euler(0f,horizontalAngle,0f);
        }



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


        // checks if the player has clicked s and if it did it rotates the camera to the rear
        if(hasSeenRear == true)
        {
            verticalAngle = Mathf.MoveTowards(verticalAngle, -18f, rotationSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(verticalAngle, 0f,0f);
            
                if(verticalAngle == -18f)
                {
                  hasSeenRear = false;
                  rearInput = true;
                 }
                
        }

        //checks if the player has clicked s while its looking at rear and if it is then it rotates back to the center.
        if(goingBackToCenter == true)
        {
            verticalAngle = Mathf.MoveTowards(verticalAngle, 0f, rotationSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(verticalAngle, 0f, 0f);
            if(verticalAngle == 0f)
            {
                goingBackToCenter = false;
                rearInput = false;
            }
           
        }

    }


         

      

      



        // resets the position by first seeing the current rotation and moving towards the initial rotation which is 0 with some speed value.
        void ResetCameraFromSides()
        {
            horizontalAngle = Mathf.MoveTowards(horizontalAngle, 0f, returnSpeed * Time.deltaTime);
       
        }

        void LookRear()
        {
                
                Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, returnSpeed * Time.deltaTime);
            
        }

        void RearToCenter()
        {
           
                Quaternion resetRotation = Quaternion.LookRotation(center.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, resetRotation, returnSpeed * Time.deltaTime);
            
        }

       



    

}
