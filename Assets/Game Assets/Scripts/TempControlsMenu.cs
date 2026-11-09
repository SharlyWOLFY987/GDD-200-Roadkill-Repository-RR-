using System;
using UnityEngine;

public class TempControlsMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public bool controlsOnScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f; // stops time when it starts and ONLY when it starts
        controlsOnScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && controlsOnScreen == false)
        {
            controlsMenu.SetActive(true);
            controlsOnScreen = true;

        }
        else if(Input.GetKeyDown(KeyCode.C) && controlsOnScreen == true)
        {
            controlsMenu.SetActive(false);
            controlsOnScreen = false;
            Time.timeScale = 1.0f; // when the object is disabled, resume time.

        }
    }
}
