using UnityEngine;
using TMPro; // For TextMeshPro

public class ShowTextOnSpacePress : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tutorialText; // Reference to the TextMeshProUGUI element to show

    private bool hasShownText = false; // To track if the text has been shown

    private void Start()
    {
        // Ensure the text is initially hidden
        if (tutorialText != null)
        {
            tutorialText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the player presses the space bar and the text hasn't been shown
        if (Input.GetKeyDown(KeyCode.Space) && !hasShownText)
        {
            StartCoroutine(ShowTextForSeconds(5));
            hasShownText = true;
        }
    }

    private System.Collections.IEnumerator ShowTextForSeconds(float seconds)
    {
        if (tutorialText != null)
        {
            tutorialText.gameObject.SetActive(true); // Show the text
            yield return new WaitForSeconds(seconds); // Wait for the specified duration
            tutorialText.gameObject.SetActive(false); // Hide the text
        }
    }
}
