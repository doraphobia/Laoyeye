using UnityEngine;
using TMPro; // For TextMeshPro

public class TutorialSystemTrigger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tutorialText; // Reference to the TextMeshProUGUI to show/hide

    // Tag or name of objects that trigger the tutorial message
    [SerializeField]
    private string targetTag = ""; // Set the tag of objects to detect (leave empty to skip)
    [SerializeField]
    private string targetName = ""; // Set the name of objects to detect (leave empty to skip)

    private void Start()
    {
        // Hide the text initially
        if (tutorialText != null)
        {
            tutorialText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object matches the specified tag or name
        if ((!string.IsNullOrEmpty(targetTag) && other.CompareTag(targetTag)) ||
            (!string.IsNullOrEmpty(targetName) && other.gameObject.name == targetName) ||
            (string.IsNullOrEmpty(targetTag) && string.IsNullOrEmpty(targetName))) // No filtering criteria
        {
            // Show the text
            if (tutorialText != null)
            {
                tutorialText.gameObject.SetActive(true);
                Debug.Log($"Tutorial triggered by {other.gameObject.name}");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Hide the text when the object leaves the trigger
        if ((!string.IsNullOrEmpty(targetTag) && other.CompareTag(targetTag)) ||
            (!string.IsNullOrEmpty(targetName) && other.gameObject.name == targetName) ||
            (string.IsNullOrEmpty(targetTag) && string.IsNullOrEmpty(targetName))) // No filtering criteria
        {
            // Hide the text
            if (tutorialText != null)
            {
                tutorialText.gameObject.SetActive(false);
                Debug.Log($"Tutorial ended for {other.gameObject.name}");
            }
        }
    }
}
