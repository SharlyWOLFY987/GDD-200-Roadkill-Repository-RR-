using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BlogPostViewingArea : MonoBehaviour
{
    public GameObject blogPostViewingArea;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        blogPostViewingArea.GetComponent<RectTransform>().sizeDelta = new Vector2(204.2384f, 170 * gameManager.createdBlogPosts.Count);
        foreach(GameObject post in gameManager.createdBlogPosts)
        {
            post.transform.position = new Vector2(204.2384f, 170 * gameManager.createdBlogPosts.Count);
        }
    }
}
