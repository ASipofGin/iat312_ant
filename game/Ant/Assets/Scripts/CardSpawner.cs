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
    private float SpecialCardChance = 0.4f; // 40% chance for a special card



    [SerializeField]
    private string[] cardNames = { "Card 1", "Card 2", "Card 3" };
    [SerializeField]
    private string[] cardDescriptions = { "Description 1", "Description 2", "Description 3" };
    [SerializeField]
    private Sprite[] bgImages;
    [SerializeField]
    private string[] bgId;
    [SerializeField]
    private Sprite[] iconImages;

    [SerializeField]
    private string[] scardNames = { "SCard 1", "SCard 2", "SCard 3" };
    [SerializeField]
    private string[] scardDescriptions = { "SDescription 1", "SDescription 2", "SDescription 3" };
    [SerializeField]
    private Sprite[] sbgImages;
    [SerializeField]
    private string[] sbgId;
    [SerializeField]
    private Sprite[] siconImages;
    void Start()
    {
        StartCoroutine(SpawnCardsAfterDelay());
    }

    IEnumerator SpawnCardsAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        List<int> indices = GetShuffledIndices(cardNames.Length);
        int bgImageIndex = Random.Range(0, bgImages.Length); // Random index for background image, same for all regular cards

        for (int i = 0; i < indices.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, startPosition + new Vector3(cardSpacing * i, 0, 0), Quaternion.identity);
            card.transform.SetParent(this.transform, false);

            Card cardScript = card.GetComponent<Card>();
            if (cardScript != null)
            {
                if (i == 2 && Random.value < SpecialCardChance)
                {
                    // Use special card arrays
                    int sIndex = Random.Range(0, scardNames.Length);
                    cardScript.SetupCard(scardNames[sIndex], scardDescriptions[sIndex], sbgImages[0], sbgId[0], siconImages[sIndex]);
                }
                else
                {
                    // Use regular card arrays
                    int index = indices[i];
                    cardScript.SetupCard(cardNames[index], cardDescriptions[index], bgImages[bgImageIndex], bgId[bgImageIndex], iconImages[index]);
                }
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
