using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public Boundaries bound;
    public Vector3 AnthillstartingPosition = new Vector3((float)-11.99, (float)-3.77, 0);
    public Vector3 MasterstartingPosition = new Vector3((float)-6.37282, (float)-0.35, 0);  
    public float moveDistanceInPixels = 500f; // 500 pixels
    public float moveDurationInSeconds = 2.0f; // 2 seconds



    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        if (sceneName == "MASTER") 
		{
            // Find the player character in the scene
            GameObject player = GameObject.FindWithTag("Player"); // Assuming the player has the tag "Player"

            // Get the CharacterMovement component from the player
            if (player != null)
            {
                characterMovement = player.GetComponent<CharacterMovement>();
                bound = player.GetComponent<Boundaries>();

                bound.enabled = true;
            }

            if (characterMovement != null)
            {          
                characterMovement.transform.position = MasterstartingPosition;
                characterMovement.EnableMovement();
            }
		}
		else if (sceneName == "Anthill Test")
		{
            // Find the player character in the scene
            GameObject player = GameObject.FindWithTag("Player"); // Assuming the player has the tag "Player"

            // Get the CharacterMovement component from the player
            if (player != null)
            {
                characterMovement = player.GetComponent<CharacterMovement>();
                bound = player.GetComponent<Boundaries>();

                bound.enabled = false;
            }

            if (characterMovement != null)
            {
                characterMovement.transform.position = AnthillstartingPosition;
                StartCoroutine(characterMovement.MoveRight(moveDistanceInPixels, moveDurationInSeconds));
            }
        }






    }
    // Update is called once per frame
    void Update()
    {
        // Additional logic can be added here if needed
    }

    public void exitScene(){
        if (characterMovement != null)
        {
            StartCoroutine(characterMovement.MoveRight(2000f, 2.5f));
        }

    }

    public void DestroyAllCards()
    {
        // Find all game objects tagged as "Card"
        GameObject[] cardObjects = GameObject.FindGameObjectsWithTag("Card");

        // Loop through them and destroy each one
        foreach (var card in cardObjects)
        {
            Destroy(card);
        }
    }
}
