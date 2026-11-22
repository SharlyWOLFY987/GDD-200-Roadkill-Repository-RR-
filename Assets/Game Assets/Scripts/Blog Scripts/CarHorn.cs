using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class CarHorn : MonoBehaviour
{
    [Header("What to Know about This Script")]
    [TextArea(1, 1000)]
    [Tooltip("Doesn't do anything! It needs to be here anyways")]
    public string tldr = "";

    
    [Header("Honking")]
    public bool isHonking = false;
    public GameObject leftLight;
    public GameObject rightLight;
    public float headlightBrightnessDifference;
    public ScreenShake screenShake; 
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
            //StartCoroutine(screenShake.Shaking());
            screenShake.start = true;
        }
        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            leftLight2D.intensity -= headlightBrightnessDifference;
            rightLight2D.intensity -= headlightBrightnessDifference;
            screenShake.start = false;
        }
        //Debug.Log(isHonking);
    }
}
