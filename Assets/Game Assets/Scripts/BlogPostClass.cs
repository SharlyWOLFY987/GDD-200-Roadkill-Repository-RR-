using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlogPostClass : MonoBehaviour
{
    /*
    BLOGPOST ATTRIBUTES
    public String postTitle = Name of the Photo (used for getting the photo into the gallery)
    public String cryptidTag; name of the cryptid the photo is associated with (or none)
    public String photoTitle; the name of the photo that the user selected
    */
    private Texture evidencePhoto; //the photo from the photo gallery
    private String postTitle; //self explanatory
    private List<String> postComments;  // where the comments will be stored, it's a list so you can add to it as much as you'd like
    // likes/dislikes
    public int likes;
    public int dislikes;
    public int maxLikes; // the max likes that can be on a post
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DisplayPost()
    {
        
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
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 10.0f));
                dislikes++;
                postComments.Add("Negative comment");

        }else if(accuracy == "roadkill")
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
