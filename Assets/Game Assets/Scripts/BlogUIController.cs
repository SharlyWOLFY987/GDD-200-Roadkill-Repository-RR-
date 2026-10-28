using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject blogUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blogUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            blogUI.SetActive(!blogUI.activeSelf);
        }
    }
}
