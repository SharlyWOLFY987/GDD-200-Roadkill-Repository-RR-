using TMPro;
using UnityEngine;

public class LaptopClock : MonoBehaviour
{
    public TMP_Text carClock;
    public TMP_Text laptopClock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laptopClock.text = carClock.text;
    }
}
