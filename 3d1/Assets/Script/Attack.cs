using UnityEngine;
using UnityEngine.SceneManagement; // To allow for scene reloading

public class PlayerDeathOnTrigger : MonoBehaviour
{
    public string enemyTag = "Enemy"; // Tag of the objects that will trigger the player's death

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
