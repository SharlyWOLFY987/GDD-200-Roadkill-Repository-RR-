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
    [Header("Car Damage")]
    public GameObject carDamage1;
    public GameObject carDamage2;
    public GameObject carDamage3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void DamageCar(){
        if(carDamage == 1)
        {
            carDamage1.SetActive(true);
        }
        if(carDamage == 2)
        {
            carDamage2.SetActive(true);
        }
        if(carDamage == 3)
        {
            carDamage3.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        credBarReference.SetCredibility(50+(totalLikes-totalDislikes));
        credibility = credBarReference.GetComponent<Slider>().value; // sets credibility to the value of the slider for this and other scripts to use

        //credibility end condition
        if(credibility < 20 && createdBlogPosts.Count > 3)
        {
            //end the game
            Debug.Log("You've been banned!");
        }

        //car damage end condition
        if(carDamage >= 3)
        {
            //end the game with car damage end screen
        }
        
        if(credibility > 80 && theDeerManProven && theEntProven)
        {
            //win the game!
        }
    }
}
