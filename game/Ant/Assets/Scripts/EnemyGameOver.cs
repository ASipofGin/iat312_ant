using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyGameOver : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the game over panel in your UI
    private bool isGameOver = false;
    private AudioSource backgroundMusic;

    private void Start()
    {
        // Find the AudioSource component in the scene
        backgroundMusic = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isGameOver)
        {
            // Pause the background music if an AudioSource is found
            if (backgroundMusic != null)
            {
                backgroundMusic.Pause();
            }

            // Freeze the game
            Time.timeScale = 0;

            // Show the game over panel
            gameOverPanel.SetActive(true);

            // Add a grey filter to the screen (You can use a UI Image with a grey color as a panel background)
            // Make sure to set the Alpha value to control the transparency

            // Add a restart button to the game over panel (You should set up this button in your UI)
            // You can use the Unity UI Button and handle its onClick event to restart the game.

            isGameOver = true;
        }
    }

    public void RestartGame()
    {
        // Reset the game state
        Time.timeScale = 1;

        // Resume the background music if an AudioSource is found

        // Load the first scene without unloading "Do Not Destroy On Load" objects
        SceneManager.LoadScene("YourFirstSceneName", LoadSceneMode.Additive);
        
        // Unload the current scene (assuming this script is attached to an object in the scene you want to unload)
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
