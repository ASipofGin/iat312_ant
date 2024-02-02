using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private GameObject distanceCounter;
    private GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        // Find the game objects
        distanceCounter = GameObject.Find("Distance Counter"); // Replace with the exact name of your distance counter object
        titleScreen = GameObject.Find("TitleScreen"); // Replace with the exact name of your title screen object

        // Check if the GameObjects were found
        if (distanceCounter == null)
        {
            // Debug.LogError("Distance counter not found");
        }
        if (titleScreen == null)
        {
            Debug.LogError("Title screen not found");
        }

        // Hide the distance counter initially
        if (distanceCounter != null)
        {
            distanceCounter.SetActive(false);
        }

        Time.timeScale = 0.0f;

        // Add a click event listener to the button
        GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;

        // Hide title screen and show distance counter
        if (titleScreen != null)
        {
            titleScreen.SetActive(false);
        }

        if (distanceCounter != null)
        {
            distanceCounter.SetActive(true);
        }
    }
}
