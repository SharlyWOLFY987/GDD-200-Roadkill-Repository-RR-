using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    private DemoCameraMovement cameraScript;

    public GameObject rearCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraScript = GetComponent<DemoCameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    


        if (cameraScript.verticalAngle == -12f)
        {
            rearCamera.SetActive(true);
        }
        if(cameraScript.goingBackToCenter == true)
        {
            rearCamera.SetActive(false);
        }

        

    }
}
