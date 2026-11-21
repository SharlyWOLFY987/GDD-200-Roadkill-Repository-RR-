using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public CameraController CameraController;
    public Slider sensitivitySlider;

    public void setSensitivity()
    {
        CameraController.cameraRotationSpeed = sensitivitySlider.value;
    }

}
