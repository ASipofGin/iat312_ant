using UnityEngine;

public class EnemyMove : MonoBehaviour

{
    public float speed = 5.0f; // Speed of the enemy movement
    public GameObject player;  // Reference to the player GameObject
    [SerializeField] private Stats stats;
    [SerializeField] private float speedMult;

    [SerializeField] private float startOffset;
    public float distanceToPlayer;

    private void Awake()
    {
        GameObject statsObj = GameObject.FindGameObjectWithTag("GameController");
        stats = statsObj.GetComponent<Stats>();
        speedMult = stats.antLionSpeedMult();
        speed = speed * speedMult;

        startOffset = stats.getOffset() + 1f;
        Debug.Log("Startoffset set");

    }

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x - startOffset -11, 1.34f, 0);

        Debug.Log("Plater pos:" + player.transform.position.x);
        Debug.Log("Start offset: "+ startOffset);
        Debug.Log(player.transform.position.x - startOffset);
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
