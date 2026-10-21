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

    private bool isFading = false;
    private Transform player;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

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

    private IEnumerator FadeAndTransition()
    {
        isFading = true;

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

        isFading = false;
    }

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
}