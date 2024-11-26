using UnityEngine;

public class TriggerSpecificObjectsDisabler : MonoBehaviour
{
    // List of script names to disable upon entering the trigger
    [SerializeField]
    private string[] scriptsToBanNames; // Array of script names to disable

    // Tag or name of objects to detect
    [SerializeField]
    private string targetTag = ""; // Set this to the tag of the objects you want to detect (leave empty to ignore tag check)
    [SerializeField]
    private string targetName = ""; // Set this to the name of the objects you want to detect (leave empty to ignore name check)

    // When another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object matches the specified tag or name
        if ((!string.IsNullOrEmpty(targetTag) && other.CompareTag(targetTag)) ||
            (!string.IsNullOrEmpty(targetName) && other.gameObject.name == targetName) ||
            (string.IsNullOrEmpty(targetTag) && string.IsNullOrEmpty(targetName))) // If both tag and name are empty, allow all
        {
            // Disable each specified script on the detected object
            foreach (string scriptName in scriptsToBanNames)
            {
                Component scriptToBan = other.gameObject.GetComponent(scriptName) as MonoBehaviour;

                if (scriptToBan != null)
                {
                    ((MonoBehaviour)scriptToBan).enabled = false; // Disable the script
                    Debug.Log($"{scriptName} has been banned/disabled on {other.gameObject.name}");
                }
            }
        }
    }
}
