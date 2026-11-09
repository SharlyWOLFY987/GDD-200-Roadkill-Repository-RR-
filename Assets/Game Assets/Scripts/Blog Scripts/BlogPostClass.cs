using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BlogPostClass : MonoBehaviour
{
    private Texture evidencePhoto; //the photo from the photo gallery
    private String thisPostTitle; //self explanatory
    private String thisCryptidTag;
    private List<String> postComments;  // where the comments will be stored, it's a list so you can add to it as much as you'd like
    //[Header("Getting User Input")]
    private CreateBlogPost createBlogPost; //reference to create blog post script for user input
    private GameManager gameManager;
    [Header("Post Component References")]
    public GameObject postTitleDisplay; // reference for the title of the post
    public GameObject cryptidTagsDisplay;
    public GameObject likesDisplay;
    public GameObject dislikesDisplay;
    public GameObject postImageDisplay; // weird gimmick with prefabs needs this to be a game object and not a RawImage type
    private GameObject parentInCanvas; //the object that the post parents to
    // likes/dislikes
    public int likes;
    public int dislikes;
    public int maxEngagement; // the max likes that can be on a post
    //comments
    private PostComment postComment; //calls the comment script to run - Alana

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //all content from this is in awake
    }
    void Awake()
    {
        Debug.Log("Awake is working!");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //reference to game manager script
        parentInCanvas = GameObject.Find("BlogPostViewingAreaContent"); // this name should be whatever the object is for viewing the blogposts
        createBlogPost = gameManager.createBlogPostScriptObjectReference.GetComponent<CreateBlogPost>(); //previously GameObject.Find("CryptidOptions").GetComponent<CreateBlogPost>();
        thisPostTitle = createBlogPost.postTitle;
        thisCryptidTag = createBlogPost.cryptidTag;
        evidencePhoto = createBlogPost.postImage;

        postComment = GetComponent<PostComment>(); // - Alana

        maxEngagement = UnityEngine.Random.Range(10, 50);
        
        DisplayPost();

        CheckAccuracy();
    }
    void OnEnable()
    {
        CheckAccuracy();
    }

    public void CheckAccuracy()
    {
        //gets the name of the entity in the selected image
        String[] parts = evidencePhoto.name.Split('_');
        String entityInPhoto = parts[0].Replace(" ", "");
        entityInPhoto = entityInPhoto +"\n"; // adds new line to ensure correct comparison
        String postTagForComparison = thisCryptidTag.Replace(" ", ""); // for some reason this is getting the tag with a new line, hence the +\n above
        //compares the entity in the photo with the tag the post has
        if(String.Equals(entityInPhoto, postTagForComparison, StringComparison.Ordinal))
        {
            Debug.Log("Post is correctly tagged!");
            postComment.ShowComment(true); // - Alana
            StartCoroutine(EvaluatePostAccuracy("correct"));
        }else if(!String.Equals(entityInPhoto, postTagForComparison, StringComparison.Ordinal))
        {
            Debug.Log("Post is incorrectly tagged!");
            postComment.ShowComment(false); // - Alana
            StartCoroutine(EvaluatePostAccuracy("incorrect"));
        }
    }
    public void DisplayPost() // updates all the parts that need to be updated
    {
        postTitleDisplay.GetComponent<TMP_Text>().SetText(thisPostTitle);
        cryptidTagsDisplay.GetComponent<TMP_Text>().SetText("#"+thisCryptidTag);
        //postImageDisplay.GetComponent<RawImage>().texture = createBlogPost.postImage.texture; // see above explanation for postImageDisplay
        postImageDisplay.GetComponent<RawImage>().texture = evidencePhoto; //createBlogPost.imageForNewBlogPost
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
                gameManager.totalLikes++;
                //postComments.Add("Positive comment");
            }
        }else if(accuracy == "incorrect") // if the tags are not correct
        {
            for(int i = 0; i < maxEngagement; i++)
            {
                //Debug.Log("This is not correct (good thing)!");
                yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 10.0f));
                //Debug.Log("You've been disliked.");
                dislikes++;
                gameManager.totalDislikes++;
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
    }
}
