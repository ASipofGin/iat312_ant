using UnityEngine;

public class CameraDistanceTracker : MonoBehaviour
{
    private float lastXPosition;
    private Stats stats;

    void Start()
    {
        // Initialize the last position with the current position
        lastXPosition = 0f;

        // Find the Stats object in the scene (assuming there is only one)
        stats = FindObjectOfType<Stats>();
    }

    void Update()
    {
        float currentXPosition = transform.position.x;

        // Check if the camera has moved to the right
        if (currentXPosition > lastXPosition)
        {
            // Calculate the distance moved to the right
            float distanceMoved = currentXPosition - lastXPosition;

            // Call addScore function with the distance moved as an argument
            stats.addScore(distanceMoved*100);

            // Update the last position
            lastXPosition = currentXPosition;
        }
    }
}
