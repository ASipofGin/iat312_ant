using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Importing the UI namespace

public class DisplayScore : MonoBehaviour
{
    public Text scoreText; // Reference to the Text component
    private Stats stats;   // Reference to the Stats component

    // Start is called before the first frame update
    void Start()
    {
        // Assuming Stats.cs is attached to the same GameObject as this script
        GameObject statsObj = GameObject.FindGameObjectWithTag("GameController");
        stats = statsObj.GetComponent<Stats>();
        scoreText = GetComponent<Text>();


        if (stats == null)
        {
            Debug.LogError("Stats component not found on the GameObject");
        }

        if (scoreText == null)
        {
            Debug.LogError("Score Text reference not set in the inspector");
        }

        if (stats != null && scoreText != null)
        {

            Debug.Log("AHWADHJNALKAJHSLKDJSAKLDJ");
            int score = stats.getScore(); // Call getScore method from Stats.cs
            scoreText.text = "Score: " + score.ToString(); // Update the text element
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
