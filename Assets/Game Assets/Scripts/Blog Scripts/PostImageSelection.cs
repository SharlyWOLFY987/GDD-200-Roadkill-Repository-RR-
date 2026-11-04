using System.Collections.Generic; // here for list use
using UnityEngine;
using UnityEngine.UI;

public class PostImageSelection : MonoBehaviour
{
    [Header("What to Know about This Script")]
    [TextArea(1, 1000)]
    [Tooltip("Doesn't do anything! It needs to be here anyways")]
    public string tldr = "";

    public int photoIndex = 0; // used to track what photo the player is selecting
    public List<Texture> playerPhotoGallery;
    [Header("Button References")]
    public Button nextPhotoButton;
    public Button previousPhotoButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPhotoGallery = GameObject.Find("Main Camera").GetComponent<CameraRecognizeObjects>().photoGalleryList; //assigns the player gallery from the script in our script
    }
    public void NextPhoto()
    {
        photoIndex++;
    }
    public void PreviousPhoto()
    {
        photoIndex--;
    }
    // Update is called once per frame
    void Update()
    {
        //prevents negative photo index
        if(photoIndex < 0)
        {
            photoIndex = 0;
        }
        //prevents photo index being greater than the amount of photos the player has
        if(photoIndex > playerPhotoGallery.Count)
        {
            photoIndex = playerPhotoGallery.Count; 
        }

        if(playerPhotoGallery.Count != 0)
        {
            if(photoIndex == 0)
            {
                previousPhotoButton.interactable = false; //keeps the button visible but not usable
            }
            else
            {
                previousPhotoButton.interactable = true;
            }
            if(photoIndex == playerPhotoGallery.Count - 1) //if at the end of the photo gallery, disable the button
            {
                nextPhotoButton.interactable = false; //keeps the button visible but not usable
            }
            else
            {
                nextPhotoButton.interactable = true;
            }
            GetComponent<RawImage>().texture = playerPhotoGallery[photoIndex];
        }
        else // if the photo gallery is empty
        {
            //removes image in photo gallery if empty and resets the color
            GetComponent<RawImage>().texture = default;
            GetComponent<RawImage>().color = new Color(50, 56, 67);
            previousPhotoButton.interactable = false;
            nextPhotoButton.interactable = false;
        }
    }
        
}
