using UnityEngine;

public class EnemyMove : MonoBehaviour

{
    public float speed = 5.0f; // Speed of the enemy movement
    public GameObject player;  // Reference to the player GameObject
    [SerializeField] private Stats stats;
    [SerializeField] private float speedMult;
    public float distanceToPlayer;

    private void Awake()
    {
        GameObject statsObj = GameObject.FindGameObjectWithTag("GameController");
        stats = statsObj.GetComponent<Stats>();
        speedMult = stats.antLionSpeedMult();
        speed = speed * speedMult;

    }

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {

        // Move the enemy to the right
        transform.Translate(speed * Time.deltaTime, 0, 0);

        // Calculate the distance to the player in centimeters
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position) - 11; // Convert meters to centimeters

    }

    public float returnDist(){
        return distanceToPlayer;
    }

    public void addSpeed(float percentage){
        speed = speed * percentage;
    }
}
