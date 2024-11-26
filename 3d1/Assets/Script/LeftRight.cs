using UnityEngine;

public class ObjectMoveLeftRight : MonoBehaviour
{
    public float speed = 2f;  // Speed of movement
    public float range = 5f;  // Distance from the starting position to move left and right

    private Vector3 startPosition;  // To store the initial position
    private bool movingRight = true; // Direction of movement

    void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the target position
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            // If the object goes beyond the range, change direction
            if (transform.position.x >= startPosition.x + range)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            // If the object goes beyond the range, change direction
            if (transform.position.x <= startPosition.x - range)
            {
                movingRight = true;
            }
        }
    }
}
