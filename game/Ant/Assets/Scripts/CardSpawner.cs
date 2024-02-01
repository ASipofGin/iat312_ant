// using UnityEngine;
// using System.Collections;

// public class CardSpawner : MonoBehaviour
// {
//     public GameObject cardPrefab; // Assign your card prefab in the inspector
//     public Vector3 startPosition; // Starting position for the first card
//     public float cardSpacing = 2.0f; // Space between the cards
//     public float spawnDelay = 5.0f; // Time in seconds before the cards spawn, adjustable in the editor

//     // Example card data - replace this with your actual card data
//     [SerializeField]
//     private string[] cardNames = { "Card 1", "Card 2", "Card 3" };
//     [SerializeField]
//     private string[] cardDescriptions = { "Description 1", "Description 2", "Description 3" };
//     [SerializeField]
//     private Sprite[] bgImages; // Assuming you have card images, assign them here
//     [SerializeField]
//     private Sprite[] iconImages; // Assuming you have card images, assign them here
    

//     void Start()
//     {
//         StartCoroutine(SpawnCardsAfterDelay());
//     }

//     IEnumerator SpawnCardsAfterDelay()
//     {
//         // Wait for the specified delay time before continuing
//         yield return new WaitForSeconds(spawnDelay);

//         // Now spawn the cards
//         for (int i = 0; i < 3; i++)
//         {
//             // Instantiate the card
//             GameObject card = Instantiate(cardPrefab, startPosition + new Vector3(cardSpacing * i, 0, 0), Quaternion.identity);
//             card.transform.SetParent(this.transform, false); // Set the card's parent to this object (for organization)

//             // Setup the card with its properties
//             Card cardScript = card.GetComponent<Card>();
//             if (cardScript != null)
//             {
//                 cardScript.SetupCard(cardNames[i], cardDescriptions[i], bgImages[i], iconImages[i]);
//             }
//         }
//     }
// }
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    public Vector3 startPosition;
    public float cardSpacing = 2.0f;
    public float spawnDelay = 5.0f;

    [SerializeField]
    private string[] cardNames = { "Card 1", "Card 2", "Card 3" };
    [SerializeField]
    private string[] cardDescriptions = { "Description 1", "Description 2", "Description 3" };
    [SerializeField]
    private Sprite[] bgImages;
    [SerializeField]
    private Sprite[] iconImages;

    void Start()
    {
        StartCoroutine(SpawnCardsAfterDelay());
    }

    IEnumerator SpawnCardsAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        List<int> indices = GetShuffledIndices(cardNames.Length);
        for (int i = 0; i < indices.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, startPosition + new Vector3(cardSpacing * i, 0, 0), Quaternion.identity);
            card.transform.SetParent(this.transform, false);

            int index = indices[i];
            int bgImageIndex = Random.Range(0, bgImages.Length); // Random index for background image

            Card cardScript = card.GetComponent<Card>();
            if (cardScript != null)
            {
                cardScript.SetupCard(cardNames[index], cardDescriptions[index], bgImages[bgImageIndex], iconImages[index]);
            }
        }
    }

    private List<int> GetShuffledIndices(int length)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < length; i++)
        {
            indices.Add(i);
        }

        for (int i = 0; i < length; i++)
        {
            int temp = indices[i];
            int randomIndex = Random.Range(i, length);
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        return indices;
    }
}
