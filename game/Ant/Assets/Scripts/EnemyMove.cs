using UnityEngine;

public class EnemyMove : MonoBehaviour

{
    public float speed = 5.0f; // Speed of the enemy movement
    public GameObject player;  // Reference to the player GameObject
    public float distanceToPlayer;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {

        // Move the enemy to the right
        transform.Translate(speed * Time.deltaTime, 0, 0);

        // Calculate the distance to the player in centimeters
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position) - 11; // Convert meters to centimeters

        // Display the distance
        Debug.Log("Distance to Player: " + distanceToPlayer.ToString("F2") + " cm");
    }

    public float returnDist(){
        return distanceToPlayer;
    }
}
