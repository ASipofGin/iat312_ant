using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for handling click events

public class Card : MonoBehaviour, IPointerClickHandler
{
    // Example properties - you can add more as needed
    public CharacterMovement characterMovement;
    public string cardName;
    public string description;
    public Sprite bgImage; // The image on the card
    public Sprite iconImage; // The ICON on the card
    

    // This method is called when the card is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(cardName + " card clicked!");

        // Here, you can add logic to handle what happens when a card is clicked.
        // For example, applying a power-up to a character, changing some game state, etc.
        ApplyCardEffect();
        
        SceneController sceneController = FindObjectOfType<SceneController>();
        if (sceneController != null)
        {
            sceneController.exitScene();
            sceneController.DestroyAllCards();
        }
        else
        {
            Debug.LogError("SceneController not found in the scene.");
        }

        


    }

    // A method to define what the card does
    void ApplyCardEffect()
    {
        // Implement the effect logic here
        // This could be anything from increasing player stats, unlocking abilities, etc.
        Debug.Log("Applying effect of " + cardName);
        
        GameObject player = GameObject.FindWithTag("Player"); // Assuming the player has the tag "Player"

        if (cardName == "Card Speed 20"){
            if (player != null)
                {
                    characterMovement = player.GetComponent<CharacterMovement>();

                    characterMovement.addSpeed((float)1.20);

                }

        }

        if (cardName == "Card Speed 20"){
            if (player != null)
                {
                    characterMovement = player.GetComponent<CharacterMovement>();

                    characterMovement.addSpeed((float)1.20);

                }

        }

        // Example: if your game has a method to increase player health, call it here
        // Player.IncreaseHealth(healthBoostAmount);
    }

    // Optionally, you can have methods to set up the card properties
    public void SetupCard(string name, string desc, Sprite bg, Sprite icon)
    {
        cardName = name;
        description = desc;
        bgImage = bg;
        iconImage = icon;

        // If your card has a UI Image component, you can set its sprite like this:
        GetComponent<Image>().sprite = bgImage;

        Text descriptionText = GetComponentInChildren<Text>();
        if (descriptionText != null)
        {
            descriptionText.text = description;
        }
        else
        {
            Debug.LogError("Description Text component not found in the children of the card prefab.");
        }

        Image iconImageObj = transform.Find("IconImage").GetComponent<Image>();
        if (iconImageObj != null)
        {
            iconImageObj.sprite = iconImage;
        }
        else
        {
            Debug.LogError("Description Text component not found in the children of the card prefab.");
        }
    }
}
