using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class WASDNavMeshMovement : MonoBehaviour
    {
        NavMeshAgent m_Agent;

        [SerializeField]
        public float agentSpeed = 3.5f; // Default speed, adjustable in the Inspector
        public float rotationSpeed = 5f; // Speed for rotation adjustments
        public float movementMultiplier = 0.1f; // Multiplier to adjust input sensitivity

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_Agent.speed = agentSpeed;
        }

        void Update()
        {
            // Get WASD input
            float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
            float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

            // Calculate movement direction
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude >= 0.1f) // Check for significant input
            {
                // Calculate the desired position
                Vector3 targetPosition = transform.position + direction * movementMultiplier;

                // Set the NavMeshAgent's destination
                m_Agent.destination = targetPosition;

                // Optional: Rotate towards movement direction
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

            // Update speed in case it has been changed from Inspector
            m_Agent.speed = agentSpeed;
        }
    }
}
