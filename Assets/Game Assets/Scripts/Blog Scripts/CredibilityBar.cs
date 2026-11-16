using UnityEngine;
using UnityEngine.UI;

public class CredibilityBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxCredibility(int cred)
    {
        slider.maxValue = cred;
        slider.value = cred;
    }
    public void SetCredibility(int cred)
    {
        slider.value = cred;
    }
}
