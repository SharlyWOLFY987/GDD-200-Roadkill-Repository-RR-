using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlogPostClass : MonoBehaviour
{
    private RawImage evidencePhoto; //the photo from the photo gallery
    private String thisPostTitle; //self explanatory
    private String thisCryptidTag;
    private List<String> postComments;  // where the comments will be stored, it's a list so you can add to it as much as you'd like
    //[Header("Getting User Input")]
    private CreateBlogPost createBlogPost; //reference to create blog post script for user input
    [Header("Post Component References")]
    public GameObject postTitleDisplay; // reference for the title of the post
    public GameObject cryptidTagsDisplay;
    public GameObject likesDisplay;
    public GameObject dislikesDisplay;
    public GameObject postImageDisplay; // weird gimmick with prefabs needs this to be a game object and not a RawImage type
    public GameObject canvasReference;
    // likes/dislikes
    public int likes;
    public int dislikes;
    public int maxLikes; // the max likes that can be on a post
    public int maxDislikes; // the max dislikes that can be on a post
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasReference = GameObject.Find("Canvas");
        createBlogPost = GameObject.Find("CryptidOptions").GetComponent<CreateBlogPost>();
        thisPostTitle = createBlogPost.postTitle;
        thisCryptidTag = createBlogPost.cryptidTag;
        evidencePhoto = createBlogPost.postImage;
        transform.SetParent(canvasReference.transform); // parents comment to canvas so it's visible

        maxLikes = UnityEngine.Random.Range(10, 50);
        maxDislikes = -maxLikes;
        
        DisplayPost();
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
            for(int i = 0; i < maxLikes; i++)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 10.0f));
                likes++;
                postComments.Add("Positive comment");
            }
        }else if(accuracy == "incorrect") // if the tags are not correct
        {
            for(int i = 0; i < maxDislikes; i++)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 10.0f));
                dislikes++;
                postComments.Add("Negative comment");
            }
        }else if(accuracy == "roadkill")
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        EvaluatePostAccuracy("correct");
        likesDisplay.GetComponent<TMP_Text>().SetText(likes.ToString());
        dislikesDisplay.GetComponent<TMP_Text>().SetText(dislikes.ToString());

    }
}
