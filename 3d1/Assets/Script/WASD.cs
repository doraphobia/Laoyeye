using UnityEngine;

public class WASD : MonoBehaviour
{
    public CharacterController controller; // Reference to the CharacterController component
    public float speed = 12f;              // Player movement speed
    public float gravity = -9.81f;         // Gravity value
    public float jumpHeight = 3f;          // How high the player can jump

    Vector3 velocity;                      // Current velocity for gravity calculation
    bool isGrounded;                       // Check if the player is grounded
    bool hasJumped;                        // Check if the player has already jumped

    public Transform groundCheck;          // Position used to check if the player is on the ground
    public float groundDistance = 0.4f;    // Distance from the groundCheck to the ground
    public LayerMask groundMask;           // Layer that defines what is considered "ground"

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ensure the player sticks to the ground
            hasJumped = false; // Reset jumping state once the player lands
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && !hasJumped)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            hasJumped = true; // Set the flag so the player can't jump again in mid-air
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
