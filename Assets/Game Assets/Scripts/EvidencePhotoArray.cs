using UnityEngine;

public class EvidencePhotoArray : MonoBehaviour
{
    [Header("What to Know about This Script")]
    [TextArea(1, 1000)]
    [Tooltip("Doesn't do anything! It needs to be here anyways")]
    public string tldr = "This script stores all of the photos in the Evidence folder. As of right now, each photo does need to be added manually. It doesn't do anything else, it just stores them for other scripts.";

    // -------------------------------------------------------------------------
    public Texture[] evidenceImages; //where all of the evidence photos are stored.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
