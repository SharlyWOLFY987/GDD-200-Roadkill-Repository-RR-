using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [Header("Blog Shenanigans")]
    public List<GameObject> createdBlogPosts;
    public GameObject createBlogPostScriptObjectReference;
    public CredibilityBar credBarReference;
    public int totalLikes;
    public int totalDislikes;
    public float credibility;

    [Header("Cryptid-related")]
    public int carDamage;
    public bool theEntProven;
    public bool theDeerManProven;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        credBarReference.SetCredibility(50+(totalLikes-totalDislikes));
        credibility = credBarReference.GetComponent<Slider>().value; // sets credibility to the value of the slider for this and other scripts to use

        if(credibility < 20 && createdBlogPosts.Count > 3)
        {
            //end the game
            Debug.Log("You've been banned!");
        }
        if(credibility > 80 && theDeerManProven && theEntProven)
        {
            //win the game!
        }
    }
}
