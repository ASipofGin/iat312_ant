using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign your player's transform here in the inspector
    public float edgeThreshold = 0.8f; // The threshold for the right edge of the screen (0.8 means 80% towards the right edge)

    private Camera cam;
    private bool playerBeyondEdge = false; // New variable to track if the player is beyond the edge

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(player.position);

            // Check if player is beyond the edge
            if (viewPos.x > edgeThreshold)
            {
                playerBeyondEdge = true;
            }
            else
            {
                playerBeyondEdge = false;
            }

            // Update camera's position if player is beyond the edge
            if (playerBeyondEdge)
            {
                MoveCameraRight(player.position);
            }
        }
    }

    private void MoveCameraRight(Vector3 playerPosition)
    {
        // Update camera's position based on player's position
        Vector3 newCameraPosition = cam.transform.position;
        newCameraPosition.x = playerPosition.x - (cam.ViewportToWorldPoint(new Vector3(edgeThreshold, 0, 0)).x - cam.transform.position.x);
        cam.transform.position = newCameraPosition;
    }
}
