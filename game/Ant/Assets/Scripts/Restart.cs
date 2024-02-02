using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    private void Start()
    {
        // Add a click event listener to the Replay image button
        GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        // List of tags for DontDestroyOnLoad objects
        string[] tagsToDestroy = { "Player", "GameController", "MusicPlayer" };

        // Find and destroy objects with these tags
        foreach (string tag in tagsToDestroy)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
        }

        // Load the first scene
        SceneManager.LoadScene(0);
    }
}
