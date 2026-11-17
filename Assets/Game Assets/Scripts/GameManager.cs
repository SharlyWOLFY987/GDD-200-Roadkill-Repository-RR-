using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using System.Collections;

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
    public bool theEntProven;
    public bool theDeerManProven; 
    public int tunnelEntrancePhotosTaken; // responsible for spawning deer man
    public int roadsideWoodsPhotosTaken; // responsible for spawning the ent
    public int waterfallPhotosTaken; // spawns no entity as of now
    public bool entSpawned = false;
    public bool deerManSpawned = false;
    [Header("Car Damage")]
    public int carDamage;
    public GameObject carFront;
    public GameObject carLeft;
    public GameObject carRight;
    public GameObject leftHeadlight;
    public Sprite frontDamageLevel1;
    public Sprite frontDamageLevel2;
    public Sprite leftDamageLevel1;
    public Sprite leftDamageLevel2;
    public Sprite rightDamageLevel1;
    public Sprite rightDamageLevel2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void DamageCar(){
        if(carDamage == 1)
        {
            carFront.GetComponent<SpriteRenderer>().sprite = frontDamageLevel1;
            carLeft.GetComponent<SpriteRenderer>().sprite = leftDamageLevel1;
            carRight.GetComponent<SpriteRenderer>().sprite = rightDamageLevel1;
        }
        if(carDamage >= 2)
        {
            carFront.GetComponent<SpriteRenderer>().sprite = frontDamageLevel2;
            carLeft.GetComponent<SpriteRenderer>().sprite = leftDamageLevel2;
            carRight.GetComponent<SpriteRenderer>().sprite = rightDamageLevel2;
            //flicker headlights 
            Light2D headlightLightPiece = leftHeadlight.GetComponent<Light2D>();
            StartCoroutine(FlickerHeadlight(headlightLightPiece));
        }
        if(carDamage == 3)
        {
            //
        }
    }
    IEnumerator FlickerHeadlight(Light2D light)
    {
            light.intensity = 1;
            yield return new WaitForSeconds(Random.Range(5.0f, 20.0f));
            light.intensity = Random.Range(5.0f, 20.0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //------------------------------ car damage --------------------------------------------------
        DamageCar();
    }
    void Update()
    {
        credBarReference.SetCredibility(50+(totalLikes-totalDislikes));
        credibility = credBarReference.GetComponent<Slider>().value; // sets credibility to the value of the slider for this and other scripts to use
        
        //----------------------------- entity spawning -------------------------------------------
        if(roadsideWoodsPhotosTaken % 3 == 0 && roadsideWoodsPhotosTaken > 0 && entSpawned == false) // if photos taken is a multiple of 3
        {
            //instnatiate the ent
            Debug.Log("The Ent has spawned.");
            entSpawned = true;
        }
        if(tunnelEntrancePhotosTaken % 3 == 0 && tunnelEntrancePhotosTaken > 0 && deerManSpawned == false){ // same as above for deer man
            //instantiate the deer man
            Debug.Log("The Deer Man has spawned.");
            deerManSpawned = true;
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
