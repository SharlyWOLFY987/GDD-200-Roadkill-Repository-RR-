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
    public NavigationController navigationController; //reference to location transition

    [Header("Cryptid-related")]
    public int carDamage;
    public bool theEntProven;
    public bool theDeerManProven; 
    public int tunnelEntrancePhotosTaken; // responsible for spawning deer man
    public int roadsideWoodsPhotosTaken; // responsible for spawning the ent
    public int waterfallPhotosTaken; // spawns no entity as of now
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
        //----------------------------- entity spawning -------------------------------------------
        if(roadsideWoodsPhotosTaken % 3 == 0 && roadsideWoodsPhotosTaken > 0) // if photos taken is a multiple of 3
        {
            //instnatiate the ent
            //Debug.Log("The Ent has spawned.");
        }
        if(tunnelEntrancePhotosTaken % 3 == 0 && tunnelEntrancePhotosTaken > 0){ // same as above
            //instantiate the deer man
            //Debug.Log("The Deer Man has spawned.");
        }
        if(waterfallPhotosTaken % 3 == 0 && waterfallPhotosTaken > 0){ // same as above
            // spawn nothing, but here just in case
        }
        //--------------------------- end conditions ----------------------------------------------
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
