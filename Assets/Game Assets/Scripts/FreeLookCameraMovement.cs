using UnityEngine;

public class FreeLookCameraMovement : MonoBehaviour
{
    DemoCameraMovement cameraScript;


    public float rotationSpeed = 500f;
    public  float zoomTransitionSpeed = 8f;
    public float horizontalRotation;
    public float verticalRotation;
    public bool isGettingAxis;
    public GameObject freeLookCamera;
    public GameObject mainCamera;
    public Transform leftTarget;
    public Transform originalTarget;
    public Transform rightTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
    {
        cameraScript = mainCamera.GetComponent<DemoCameraMovement>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraScript.horizontalAngle == -60f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position = Vector3.MoveTowards(transform.position, leftTarget.position, zoomTransitionSpeed * Time.deltaTime);
                horizontalRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                verticalRotation += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
                verticalRotation = Mathf.Clamp(horizontalRotation, -45f, 45f);
                verticalRotation = Mathf.Clamp(horizontalRotation, -30f, 30f);
                transform.localRotation = Quaternion.Euler(-verticalRotation, horizontalRotation, 0f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, originalTarget.position, zoomTransitionSpeed * Time.deltaTime);
                horizontalRotation = Mathf.MoveTowards(horizontalRotation, 0f, rotationSpeed * Time.deltaTime);
                verticalRotation = Mathf.MoveTowards(verticalRotation, 0f, rotationSpeed * Time.deltaTime);
                if (horizontalRotation == 0f && verticalRotation == 0f && transform.position == originalTarget.position)
                {
                    freeLookCamera.SetActive(false);
                }
                transform.localRotation = Quaternion.Euler(-verticalRotation, horizontalRotation, 0f);
            }
        }

        if (cameraScript.horizontalAngle == 60f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position = Vector3.MoveTowards(transform.position, rightTarget.position, zoomTransitionSpeed * Time.deltaTime);
                horizontalRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                verticalRotation += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
                verticalRotation = Mathf.Clamp(verticalRotation, -45f, 45f);
                horizontalRotation = Mathf.Clamp(horizontalRotation, -30f, 30f);
                transform.localRotation = Quaternion.Euler(-verticalRotation, horizontalRotation, 0f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, originalTarget.position, zoomTransitionSpeed * Time.deltaTime);
                horizontalRotation = Mathf.MoveTowards(horizontalRotation, 0f, rotationSpeed * Time.deltaTime);
                verticalRotation = Mathf.MoveTowards(verticalRotation, 0f, rotationSpeed * Time.deltaTime);
                if (horizontalRotation == 0f && verticalRotation == 0f && transform.position == originalTarget.position)
                {
                    freeLookCamera.SetActive(false);
                }
                transform.localRotation = Quaternion.Euler(-verticalRotation, horizontalRotation, 0f);
            }
        }












    }
}
