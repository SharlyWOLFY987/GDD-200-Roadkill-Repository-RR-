using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BlogPostViewingArea : MonoBehaviour
{
    public List<GameObject> createdBlogPosts;
    public GameObject blogPostViewingArea;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blogPostViewingArea.GetComponent<RectTransform>().sizeDelta = new Vector2(204.2384f, 170 * createdBlogPosts.Count);
        foreach(GameObject post in createdBlogPosts)
        {
            post.transform.position = new Vector2(204.2384f, 170 * createdBlogPosts.Count);
        }
    }
}
