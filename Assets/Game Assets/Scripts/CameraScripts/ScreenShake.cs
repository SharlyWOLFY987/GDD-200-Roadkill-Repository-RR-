using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [Header("What to Know about This Script")]
    [TextArea(1, 1000)]
    [Tooltip("Doesn't do anything! It needs to be here anyways")]
    public string tldr = "";

    
    public float shakeDuration;
    public AnimationCurve curve;
    public bool start = false; // this is purely for testing
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            StartCoroutine(Shaking());
        }
    }

    public IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position; // stores the starting position of the camera
        float elapsedTime = 0f;

        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime; // updates elapsed time
            float strength = curve.Evaluate(elapsedTime / shakeDuration); // gets the value from the curve
            transform.position = startPosition + Random.insideUnitSphere * strength; // actually shakes the camera
            yield return null;
        }

        transform.position = startPosition; //resets camera back to start position
    }
}
