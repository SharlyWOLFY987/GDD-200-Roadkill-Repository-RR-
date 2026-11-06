using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public DemoCameraMovement demoCameraMovement;

    public void setSensitivity()
    {
        Debug.Log(demoCameraMovement.cameraRotationSpeed);
    }

}
