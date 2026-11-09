using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> createdBlogPosts;

    public GameObject createBlogPostScriptObjectReference;

    public int totalLikes;
    public int totalDislikes;
    public float sentimentRatio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sentimentRatio = totalDislikes/totalLikes;
        //sentimentRatio = totalLikes / totalDislikes ;
        if(sentimentRatio < 0.10 && createdBlogPosts.Count > 3 && totalDislikes > 10)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // transitions to game over screen
            Debug.Log("You've been ratiod!");
        }
        if(sentimentRatio > 0.8 && createdBlogPosts.Count > 8)
        {
            Debug.Log("You win the game!");
        }
    }
}
