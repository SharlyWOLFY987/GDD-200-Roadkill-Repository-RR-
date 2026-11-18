using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class NavigationController : MonoBehaviour
{
    [Header("Location Buttons")]
    public Button roadsideButton;
    public Button waterfallButton;
    public Button tunnelButton;

    [Header("Location setters")]
    public Transform roadside;
    public Transform waterfall;
    public Transform tunnel;

    [Header("Other Scripts")]
    public LocationTransition locationTransition;

    public string currentLocation = "roadside";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roadsideButton.onClick.AddListener(() => SetDestination(roadside));
        roadsideButton.onClick.AddListener(() => currentLocation = "roadside");

        waterfallButton.onClick.AddListener(() => SetDestination(waterfall));
        waterfallButton.onClick.AddListener(() => currentLocation = "waterfall");

        tunnelButton.onClick.AddListener(() => SetDestination(tunnel));
        tunnelButton.onClick.AddListener(() => currentLocation = "tunnel");
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void SetDestination(Transform destination)
    {
        if (destination == locationTransition.CurrentLocation)
        {
            Debug.Log("Already at " + destination.name);
            return;
        }

        locationTransition.SetTargetLocation(destination);
        locationTransition.StartTransition();
    }
}