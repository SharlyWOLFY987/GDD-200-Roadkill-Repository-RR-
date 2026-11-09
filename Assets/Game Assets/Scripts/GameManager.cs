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
        //sentimentRatio = totalLikes / totalDislikes ;
        if(sentimentRatio < 0.10 && createdBlogPosts.Count > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // transitions to game over screen
        }

    }
}
