using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class CarHorn : MonoBehaviour
{
    [Header("Honking")]
    public bool isHonking = false;
    public GameObject leftLight;
    public GameObject rightLight;
    public float headlightBrightnessDifference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //honking!
        isHonking = false;
        Light2D leftLight2D = leftLight.GetComponent<Light2D>();
        Light2D rightLight2D = rightLight.GetComponent<Light2D>();
        if(Keyboard.current.spaceKey.isPressed)
        {
            isHonking = true;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            leftLight2D.intensity += headlightBrightnessDifference;
            rightLight2D.intensity += headlightBrightnessDifference;
        }
        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            leftLight2D.intensity -= headlightBrightnessDifference;
            rightLight2D.intensity -= headlightBrightnessDifference;
        }
        Debug.Log(isHonking);
    }
}
