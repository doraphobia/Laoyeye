using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f); // Rotation speed on each axis (x, y, z)

    void Update()
    {
        // Rotate the object
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
