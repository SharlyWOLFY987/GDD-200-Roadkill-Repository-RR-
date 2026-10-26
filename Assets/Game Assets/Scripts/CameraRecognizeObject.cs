using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UI; //technically not neccesary as of now, but here in case I need to change how the Photos are stored in the Photo Gallery

//https://www.youtube.com/watch?v=B34iq4O5ZYI tutorial I used if you're curious!
public class CameraRecognizeObjects : MonoBehaviour
{
    //variables
    Ray photoCameraRaycast; // this is what's used to check what object is in frame

    [Header("What to Know about This Script")]
    [TextArea(1, 1000)]
    [Tooltip("Doesn't do anything! It needs to be here anyways")]
    public string tldr = "This script gets the name of the object you are looking at, and when you press left click it will add the photo of the object into the photo gallery. \nIn order for this script to work, make sure that each piece of evidence is on the EvidenceObjects layer. \nAdditionally, the game object and name of photo must match exactly.";

    [Header("Object Detection")]
    public LayerMask evidenceLayer; //set in Unity, this should be the layer that all evidence objects are on
    public float maxDistance; //how far the camera can detect objects, multiplied by 100 below

    [Header("Photo Taking")]
    public GameObject gameManager; // game manager reference
    private EvidencePhotoArray evidencePhotoArray; //in-script reference for the evidence photos
    public List<Texture> photoGalleryList; //the list where the player's photos are stored. List is used for flexibility (the size is variable)
    public int collectionTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        evidencePhotoArray = gameManager.GetComponent<EvidencePhotoArray>(); // gets all of the evidence photos in the game (NOT what goes into the photo gallery)
    }
    IEnumerator RemoveEvidenceRoutine(GameObject obj)
    {
        Debug.Log("Removing "+ obj.name +"!");
        //play sound of car door openin/closing here!
        yield return new WaitForSeconds(collectionTime); //wait for collectionTime seconds, then disable the object
        obj.SetActive(false);
        Debug.Log("Removed "+ obj.name +"!");

    }

    // Update is called once per frame
    void Update()
    {
        photoCameraRaycast = new Ray(transform.position, transform.forward); //sets the position of the raycast from the position of the object it's on
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);//visualizes the camera object detection, this will not be visible in the game
       //declare raycast variable
        if(Physics.Raycast(photoCameraRaycast, out RaycastHit hit, maxDistance * 100, evidenceLayer)){ //if an object on the evidence layer is in line of sight of the camera
            String objectHitName = hit.collider.gameObject.name;
            //Debug.Log(objectHitName + " was detected."); //gets the name of the game object the raycast hits
            //toggle photo is ready UI element! (the same as the previous one with a couple of element added on)
            if (Input.GetMouseButtonDown(0)) //when left mouse is pressed
            {
                for(int i = 0; i < evidencePhotoArray.evidenceImages.Length; i++)
                {
                    //Debug.Log(i); //puts the amount of evidence photos total into the log (for testing)
                    //if the name of the game object and the name of the image are the same
                    if(objectHitName == evidencePhotoArray.evidenceImages[i].name){
                        photoGalleryList.Add(evidencePhotoArray.evidenceImages[i]);
                        //Debug.Log("Added " + evidencePhotoArray.evidenceImages[i].name + " photo to camera!");//add the photo to camera here! (This is for testing)
                        StartCoroutine(RemoveEvidenceRoutine(hit.collider.gameObject));// toggles the game object off a few seconds after taking the picture
                        //hit.collider.gameObject.SetActive(false); // replaced with coroutine
                    }
                    else{
                        Debug.Log("No photo could be found."); //if no photo matches the thing (For testing)
                    }
                }
            }
        }
        else
        {
            Debug.Log("Nothing was detected."); //for bug fixing
        }
    }
}
