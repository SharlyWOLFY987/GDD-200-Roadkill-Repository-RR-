using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject blogUI;
    public bool inLaptop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blogUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && inLaptop == false)
        {
            inLaptop = true;
            blogUI.SetActive(!blogUI.activeSelf);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }else if(Input.GetKeyDown(KeyCode.Tab) && inLaptop == true)
        {
            inLaptop = false;
            blogUI.SetActive(!blogUI.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
