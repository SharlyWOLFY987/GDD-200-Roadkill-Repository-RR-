using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class PassageOfTime : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public float _timeRemaining = 600;


    void Start()
    {
        
    }


    void Update()
    {
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining < 0) _timeRemaining = 0;
        int seconds = Mathf.FloorToInt(_timeRemaining % 60);
        int minutes = Mathf.FloorToInt(_timeRemaining / 60);
        if (_timeRemaining == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        _text.text = string.Format("{0,00}:{1,00}", minutes, seconds);
    }
}
