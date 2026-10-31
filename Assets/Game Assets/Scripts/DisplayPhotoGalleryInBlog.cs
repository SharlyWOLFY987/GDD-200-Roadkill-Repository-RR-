using System.Collections.Generic; // here for list use
using UnityEngine;
using UnityEngine.UI;

//https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.RawImage.html (RawImage documentation)
public class DisplayPhotoGalleryInBlog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("What to Know about This Script")]
    [TextArea(1, 1000)]
    [Tooltip("Doesn't do anything! It needs to be here anyways")]
    public string tldr = "";
    private List<Texture> playerPhotoGallery;
    private List<RawImage> photoSlots; // all avaliable photo slots in the gallery
    void Start()
    {
        playerPhotoGallery = GameObject.Find("Main Camera").GetComponent<CameraRecognizeObjects>().photoGalleryList; //assigns the player gallery from the script in our script;
        photoSlots = new List<RawImage>();//creates the storage
        foreach(Transform child in transform) // for every RawImage object on the GameObject this is attached to
        {
            photoSlots.Add(child.GetComponent<RawImage>());
            //Debug.Log("Added RawImage to list!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable() //when this game object is enabled
    {
        updatePhotos();
    }
    void updatePhotos()
    {
        for(int i = 0; i < photoSlots.Count; i++) //photoSlots.Count is the length of the photoSlots list
        {
            photoSlots[i].texture = playerPhotoGallery[i];
        }
    }
}
