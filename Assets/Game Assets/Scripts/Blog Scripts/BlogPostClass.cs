using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BlogPostClass : MonoBehaviour
{
    private RawImage evidencePhoto; //the photo from the photo gallery
    private String thisPostTitle; //self explanatory
    private String thisCryptidTag;
    private List<String> postComments;  // where the comments will be stored, it's a list so you can add to it as much as you'd like
    //[Header("Getting User Input")]
    private CreateBlogPost createBlogPost; //reference to create blog post script for user input
    public GameObject gameManager;
    [Header("Post Component References")]
    public GameObject postTitleDisplay; // reference for the title of the post
    public GameObject cryptidTagsDisplay;
    public GameObject likesDisplay;
    public GameObject dislikesDisplay;
    public GameObject postImageDisplay; // weird gimmick with prefabs needs this to be a game object and not a RawImage type
    public GameObject parentInCanvas;
    // likes/dislikes
    public int likes;
    public int dislikes;
    public int maxEngagement; // the max likes that can be on a post
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //parentInCanvas = GameObject.Find("BlogPostViewing");
        createBlogPost = GameObject.Find("CryptidOptions").GetComponent<CreateBlogPost>();
        thisPostTitle = createBlogPost.postTitle;
        thisCryptidTag = createBlogPost.cryptidTag;
        evidencePhoto = createBlogPost.postImage;
        transform.SetParent(parentInCanvas.transform); // parents comment to canvas so it's visible

        maxEngagement = UnityEngine.Random.Range(10, 50);
        
        DisplayPost();

        //gets the name of the entity in the selected image
        String[] parts = createBlogPost.postImage.texture.name.Split('_');
        String entityInPhoto = parts[0].Replace(" ", "");
        Debug.Log("Entity in photo: " + entityInPhoto);
        //Debug.Log(entityInPhoto.Length);
        /*
        for(int i = 0; i < entityInPhoto.Length; i++)
        {
            Debug.Log(entityInPhoto[i]);
        }
        */
        String postTagForComparison = thisCryptidTag.Replace(" ", ""); // for some reason this is getting the tag with a new line
        Debug.Log("Comparison cryptid tag: " + postTagForComparison);
        //Debug.Log(postTagForComparison.Length);
        /*
        for(int i = 0; i < postTagForComparison.Length; i++)
        {
            Debug.Log(postTagForComparison[i]);
        }
       */
        //compares the entity in the photo with the tag the post has
        if(String.Equals(entityInPhoto, postTagForComparison, StringComparison.Ordinal))
        {
            Debug.Log("Post is correctly tagged!");
            EvaluatePostAccuracy("correct");
        }else if(!String.Equals(entityInPhoto, postTagForComparison, StringComparison.Ordinal))
        {
            Debug.Log("Post is incorrectly tagged!");
            EvaluatePostAccuracy("incorrect");
        }
    }

    public void DisplayPost() // updates all the parts that need to be updated
    {
        postTitleDisplay.GetComponent<TMP_Text>().SetText(thisPostTitle);
        cryptidTagsDisplay.GetComponent<TMP_Text>().SetText("#"+thisCryptidTag);
        postImageDisplay.GetComponent<RawImage>().texture = createBlogPost.postImage.texture; // see above explanation for postImageDisplay
    }

    IEnumerator EvaluatePostAccuracy(String accuracy) // accuracy is if the tags match
    {
        if(accuracy == "correct") // if the tags are correct
        {
            for(int i = 0; i < maxEngagement; i++)
            {
                //Debug.Log("Accuracy is correct!");
                yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 10.0f));
                //Debug.Log("Added likes successfully!");
                likes++;
                //postComments.Add("Positive comment");
            }
        }else if(accuracy == "incorrect") // if the tags are not correct
        {
            for(int i = 0; i < maxEngagement; i++)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 10.0f));
                dislikes++;
                //postComments.Add("Negative comment");
            }
        }else if(accuracy == "roadkill")
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        likesDisplay.GetComponent<TMP_Text>().SetText(likes.ToString());
        dislikesDisplay.GetComponent<TMP_Text>().SetText(dislikes.ToString());
        //gameManager.totalLikes += likes;
        //gameManager.totalDislikes += dislikes;
    }
}
