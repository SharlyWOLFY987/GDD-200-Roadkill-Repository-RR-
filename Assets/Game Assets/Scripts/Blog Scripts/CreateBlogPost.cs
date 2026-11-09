using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System;
using System.Collections;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEditor.SearchService;

public class CreateBlogPost : MonoBehaviour
{
    public GameObject blogPostPrefab;
    private GameManager gameManager;
    public GameObject blogPostView;
    //private BlogPostViewingArea blogPostViewingArea;
    private BlogPostClass blogPostClass;
    private PostImageSelection postImageSelection;
    public TMP_InputField postTitleInput;
    public String postTitle;
    public String cryptidTag;
    public ToggleGroup cryptidSelection;
    public Texture postImage;
    [Header("Other Blog Tabs")]
    public GameObject createPostTab;
    public GameObject blogHomeTab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        postImage = postImageSelection.playerPhotoGallery[postImageSelection.photoIndex];
        // instantiates blog post at the position and rotation of the blog post viewing area, as well as parents to it
        GameObject newPost = Instantiate(blogPostPrefab, blogPostView.transform.position, blogPostView.transform.rotation, blogPostView.transform); 
        gameManager.createdBlogPosts.Add(newPost); // adds the post to 

        StartCoroutine(RemoveImageFromGallery());

        postTitleInput.text = ""; // clears post title after the image has been removed
    }

    public void DelayedSetActive(GameObject obj)
    {
        StartCoroutine(DelayTime());
        if(obj.activeSelf == true)
        {
            obj.SetActive(false);
        }else if(obj.activeSelf == false)
        {
            obj.SetActive(true);
        }
    }

    IEnumerator RemoveImageFromGallery() // neccesary because the new blog post would get the wrong image
    {
        yield return new WaitForSeconds(0.01f);
        postImageSelection.playerPhotoGallery.RemoveAt(postImageSelection.photoIndex); // removes the photo after the player makes a post with it
        if(postImageSelection.photoIndex >= postImageSelection.playerPhotoGallery.Count)
        {
             postImageSelection.photoIndex--; // this prevents out of bounds error
        }
        Debug.Log("Photo was removed successfully!");
        //will find a better fix later, good enough for now
        yield return new WaitForSeconds(0.01f);
        DelayedSetActive(blogHomeTab); // toggles on the blog home tab
        DelayedSetActive(createPostTab); //toggles off the create post tab
    }
    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.00f); //wait for a miniscule amount of time
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
