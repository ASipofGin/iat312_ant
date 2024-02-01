using UnityEngine;

public class DespawnLeftOfCamera : MonoBehaviour
{
    public float leftOffset = 10.0f; // Distance to the left of the camera to trigger despawn

    void Update()
    {
        // Get the camera's left boundary
        float leftCameraBoundary = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;

        // Check if the object is left of the camera boundary minus the offset
        if (transform.position.x < leftCameraBoundary - leftOffset)
        {
            // Destroy this game object
            Destroy(gameObject);
        }
    }
}
