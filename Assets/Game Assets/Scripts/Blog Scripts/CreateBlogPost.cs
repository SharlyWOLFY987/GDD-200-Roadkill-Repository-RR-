using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System;
using System.Collections;

public class CreateBlogPost : MonoBehaviour
{
    public GameObject blogPostPrefab;
    private BlogPostClass blogPostClass;
    private PostImageSelection postImageSelection;
    public TMP_InputField postTitleInput;
    public String postTitle;
    public String cryptidTag;
    public ToggleGroup cryptidSelection;
    public RawImage postImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blogPostClass = blogPostPrefab.GetComponent<BlogPostClass>(); // gets the script from the blog post
        postImageSelection = GameObject.Find("PostImageSelection").GetComponent<PostImageSelection>(); // gets the script from image selection
        cryptidSelection = GetComponent<ToggleGroup>(); //gets the toggle group for post creation
    }
    public void CreatePost()
    {
        Toggle activeToggle = cryptidSelection.ActiveToggles().FirstOrDefault();
        //updates cryptid tag each time a post is created
        cryptidTag = activeToggle.GetComponentInChildren<Text>().text;
        //Debug.Log(activeToggle.GetComponentInChildren<Text>().text);

        //updates post title each time a post is created
        postTitle = postTitleInput.GetComponent<TMP_InputField>().text;
        //updates blog image
        postImage.texture = postImageSelection.playerPhotoGallery[postImageSelection.photoIndex];
        Instantiate(blogPostPrefab);

        StartCoroutine(RemoveImageFromGallery());
    }

    IEnumerator RemoveImageFromGallery() // neccesary because the new blog post would get the wrong image
    {
        yield return new WaitForSeconds(0.01f);
        postImageSelection.playerPhotoGallery.RemoveAt(postImageSelection.photoIndex); // removes the photo after the player makes a post with it
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
