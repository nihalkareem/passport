using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // The name of the scene to load, typed in the Inspector (for example, "001")
    public string nextSceneName = "001";

    // Runs when another collider enters this trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Only load the next scene if the player touched the portal
        if (other.CompareTag("Player"))
        {
            // Load the scene by its name
            SceneManager.LoadScene(nextSceneName);
        }
    }
}