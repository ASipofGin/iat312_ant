using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    [SerializeField]
    private float topOffset = 0f; // Additional offset from the top of the screen
    [SerializeField]
    private float bottomOffset = 0f; // Additional offset from the bottom of the screen

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Assuming the character uses a Collider2D component for its size
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            objectWidth = collider.bounds.extents.x; // Extents are half the size of the Collider
            objectHeight = collider.bounds.extents.y;
        }
    }

    // Update is called once per frame
    void LateUpdate() 
    {   
        
        Vector3 viewPos = transform.position;

        // Calculate screen bounds relative to the camera position
        float screenLeft = Camera.main.transform.position.x - screenBounds.x;
        float screenRight = Camera.main.transform.position.x + screenBounds.x;

        // Adjust clamp values based on object size, camera position, and additional offsets
        viewPos.x = Mathf.Clamp(viewPos.x, screenLeft + objectWidth, screenRight - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight + bottomOffset, screenBounds.y - objectHeight - topOffset);

        transform.position = viewPos;
    }
}
