using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalLikes;
    public int totalDislikes;
    public float sentimentRatio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentimentRatio = totalLikes / totalDislikes ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
