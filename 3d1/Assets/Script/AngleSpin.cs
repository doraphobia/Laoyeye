using UnityEngine;

public class OscillatingRotation : MonoBehaviour
{
    public Transform pivot;           // The pivot or central point for rotation
    public float maxAngle = 45f;      // Maximum angle to rotate in each direction
    public float rotationSpeed = 2f;  // Speed of the rotation

    private float currentAngle = 0f;  // Tracks the current angle
    private int rotationDirection = 1; // Direction of rotation (1 for forward, -1 for backward)

    void Update()
    {
        // Calculate the angle to rotate this frame
        float angleThisFrame = rotationSpeed * Time.deltaTime * rotationDirection;

        // Update the current angle and check if it exceeds the max angle
        currentAngle += angleThisFrame;
        if (Mathf.Abs(currentAngle) >= maxAngle)
        {
            // Clamp the current angle to maxAngle and reverse the rotation direction
            currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);
            rotationDirection *= -1; // Reverse direction
        }

        // Apply rotation around the pivot
        transform.RotateAround(pivot.position, Vector3.up, angleThisFrame);
    }
}
