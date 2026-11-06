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
        blogPostViewingArea.GetComponent<RectTransform>().sizeDelta = new Vector2(451.41f,378.8f + (170 * gameManager.createdBlogPosts.Count)); // -1 because the size shouldn't change with only 1 post
    }
}
