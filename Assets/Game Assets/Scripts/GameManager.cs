using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> createdBlogPosts;

    public GameObject createBlogPostScriptObjectReference;
    public CredibilityBar credBarReference;
    public int totalLikes;
    public int totalDislikes;
    public float credibility;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        credBarReference.SetCredibility(50+(totalLikes-totalDislikes));
        credibility = credBarReference.GetComponent<Slider>().value; // sets credibility to the value of the slider for this and other scripts to use
    }
}
