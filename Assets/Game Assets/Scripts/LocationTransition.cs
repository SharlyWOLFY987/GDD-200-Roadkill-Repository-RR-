using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocationTransition : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] private Image fadeImage;
    [SerializeField] public float fadeDuration = 1f;
    public float waitTime = 2f;

    [Header("Destination")]
    [SerializeField] private Transform targetLocation;

    [Header("What to Know about This Script")]
    [TextArea(1, 1000)]
    [Tooltip("Doesn't do anything! It needs to be here anyways")]
    public string tldr = "This script loads a fade transition and moves the player to the next area.";

    [Header("Make Car Go Backwards")]
    [SerializeField] private Transform car;
    public float backwardsDistance = 2f;
    public float backwardsSpeed = 3f;
    public float backwardsTransitionDelay = 0.5f;

    [Header("Make Car Go Forwards")]
    public float forwardsDistance = 2f;
    public float forwardsSpeed = 3f;
    public float forwardsTransitionDelay = 0.5f;

    private bool isFading = false;
    private Transform player;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        Debug.Log($"LocationTransition running on {gameObject.name}");
        Debug.Log($"Target = {targetLocation}");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }
    //Temporarily set as the "K" key. Will be changed when map is created.
    private void Update()
     {
         if (Input.GetKeyDown(KeyCode.K) && !isFading)
         {
             StartCoroutine(FadeAndTransition());
         }
     }
    //Used to find why location teleport didn't work
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log($"K pressed on {gameObject.name}");
            Vector3 before = player.position;

            if (targetLocation != null)
            {
                Debug.Log($"Teleporting to {targetLocation.position}");
                player.position = targetLocation.position;
            }

            player.position = targetLocation.position;

            Debug.Log("Before: " + before);
            Debug.Log("After: " + player.position);
        }
    }
    */
    private IEnumerator FadeAndTransition()
    {
        isFading = true;

        // Move car backwards
        yield return StartCoroutine(
        MoveCar(
            -car.forward,
            backwardsDistance,
            backwardsSpeed
        )
    );

        yield return new WaitForSeconds(backwardsTransitionDelay);

        // Fade to black
        yield return StartCoroutine(Fade(1f));

        // Stay black for 2 seconds
        yield return new WaitForSeconds(waitTime);

        // Move player
        if (player != null && targetLocation != null)
        {
            player.position = targetLocation.position;
        }
        // Fade back in
        yield return StartCoroutine(Fade(0f));

        yield return new WaitForSeconds(forwardsTransitionDelay);

        // Move forwards after transition
        yield return StartCoroutine(
            MoveCar(
                car.forward,
                forwardsDistance,
                forwardsSpeed
            )
        );

        isFading = false;
    }

    //code to make fade work
    private IEnumerator Fade(float targetAlpha)
    {
        if (fadeImage == null)
            yield break;
        Color c = fadeImage.color;
        float startAlpha = c.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            c.a = Mathf.Lerp(
                startAlpha,
                targetAlpha,
                time / fadeDuration
          );

          fadeImage.color = c;

          yield return null;
      }

      c.a = targetAlpha;       fadeImage.color = c;
  }
    // code to make car move
    private IEnumerator MoveCar(
    Vector3 direction,
    float distance,
    float speed)
    {
        Vector3 startPosition = car.position;
        Vector3 targetPosition =
            startPosition + direction.normalized * distance;

        while (Vector3.Distance(car.position, targetPosition) > 0.01f)
        {
            car.position = Vector3.MoveTowards(
                car.position,
                targetPosition,
                speed * Time.deltaTime
            );

            yield return null;
        }

        car.position = targetPosition;
    }
}