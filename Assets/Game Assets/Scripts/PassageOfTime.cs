using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Collections;

public class PassageOfTime : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private float _timePassed = 0;
    public float _gameTimeInMinutes = 15;


    void Start()
    {

    }


    void Update()
    {
        _timePassed += Time.deltaTime;
        float _gameTimeInSeconds = _gameTimeInMinutes * 60;
        if (_timePassed >= _gameTimeInSeconds)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        float _currentTime = setInGameTime() * _timePassed + 36000;
        float minutes = getMinutes(_currentTime);
        float hours = getHours(_currentTime);
        string clockText = string.Format("{0:00}:{1:00}", hours, minutes);
        _text.text = clockText;
    }

    public float setInGameTime()
    {
        float timeRatio = 360.0f / _gameTimeInMinutes;
        return timeRatio;
    }

    public int getMinutes(float _time)
    {
        int minutes = Mathf.FloorToInt((_time / 60) % 60);
        return minutes;
    }
    
    public int getHours(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600) % 12;
        if( hours == 0)
        {
            hours = 12;
        }
        return hours;
    }

}
