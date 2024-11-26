using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

namespace Unity.AI.Navigation.Samples
{
    [RequireComponent(typeof(Collider))]
    public class Despawner : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
