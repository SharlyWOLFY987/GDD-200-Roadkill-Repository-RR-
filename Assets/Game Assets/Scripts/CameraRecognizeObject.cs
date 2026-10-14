using System;
using UnityEngine;

//https://www.youtube.com/watch?v=B34iq4O5ZYI tutorial I used if you're curious!
public class CameraRecognizeObjects : MonoBehaviour
{
    //variables
    Ray photoCameraRaycast; // this is what's used to check what object is in frame

    [Header("What to Know about This Script")]
    [TextArea(1, 1000)]
    [Tooltip("Doesn't do anything! It needs to be here anyways")]
    public string tldr = "This script gets the name of the GameObject the camera is looking at. \nIn order for this script to work, make sure that each piece of evidence is on the EvidenceObjects layer.";

    [Header("Object Detection")]
    public LayerMask evidenceLayer; //set in Unity, this should be the layer that all evidence objects are on
    public float maxDistance; //how far the camera can detect objects, multiplied by 100 below
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        photoCameraRaycast = new Ray(transform.position, transform.forward); //sets the position of the raycast from the position of the object it's on

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);//visualizes the camera object detection, this will not be visible in the game
       //declare raycast variable
        if(Physics.Raycast(photoCameraRaycast, out RaycastHit hit, maxDistance * 100, evidenceLayer)){ //if an object on the evidence layer is in line of sight of the camera
            Debug.Log(hit.collider.gameObject.name + " was detected."); //gets the name of the game object the raycast hits
        }
        else
        {
            Debug.Log("Nothing was detected."); //for bug fixing
        }
    }
}
