using UnityEngine;

public class BlogUIController : MonoBehaviour
{
    public GameObject blogUI;

    void Start()
    {
        blogUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            blogUI.SetActive(!blogUI.activeSelf);
        }
    }
}
