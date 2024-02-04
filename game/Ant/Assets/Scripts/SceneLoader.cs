using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string targetScene; // Name of the scene to load
    public string triggerScene; // Name of the scene where LoadTargetScene should trigger

    [SerializeField] private Stats stats;
    [SerializeField] private ShowDistance showDistance;

    private float distance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // Check if the colliding object is the player
        {
            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        // Check if the current scene is the trigger scene
        if (SceneManager.GetActiveScene().name != triggerScene)
        {
             GameObject statsObj = GameObject.FindGameObjectWithTag("GameController");
             stats = statsObj.GetComponent<Stats>();
        
            GameObject distanceObj = GameObject.FindGameObjectWithTag("DistanceCounter");
            if (distanceObj != null && statsObj != null)
        {
            showDistance = distanceObj.GetComponent<ShowDistance>();
            distance = showDistance.returnDistance();
            stats.setDistance(distance);
        }
        }

       

        SceneManager.LoadScene(targetScene); // Load the target scene
    }
}
