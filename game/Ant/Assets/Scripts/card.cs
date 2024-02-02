using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for handling click events

public class Card : MonoBehaviour, IPointerClickHandler
{
    // Example properties - you can add more as needed
    public CharacterMovement characterMovement;
    public GrassCollide grassCollide;

    public Stats statsObj;
    public string cardName;
    public string description;
    public Sprite bgImage; // The image on the card
    public string bgId;
    public Sprite iconImage; // The ICON on the card

    public int percentage;
    

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

    // Optionally, you can have methods to set up the card properties
    public void SetupCard(string name, string desc, Sprite bg, string id, Sprite icon)
    {
        cardName = name;
        description = desc;
        bgImage = bg;
        percentage = int.Parse(id) * 10;
        iconImage = icon;

        // If your card has a UI Image component, you can set its sprite like this:
        GetComponent<Image>().sprite = bgImage;

        Text descriptionText = GetComponentInChildren<Text>();
        if (descriptionText != null)
        {
            if (percentage < 90){
                descriptionText.text = description + percentage + " %";
            }else{
                descriptionText.text = description;
            }
            
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

        void ApplyCardEffect()
    {
        // Implement the effect logic here
        // This could be anything from increasing player stats, unlocking abilities, etc.
        Debug.Log("Applying effect of " + cardName);
        
        GameObject player = GameObject.FindWithTag("Player"); // Assuming the player has the tag "Player"
        GameObject stats = GameObject.FindWithTag("GameController"); // Assuming the player has the tag "Player"

        if (cardName == "Speed"){
            if (player != null)
                {
                    characterMovement = player.GetComponent<CharacterMovement>();

                    characterMovement.addSpeed((float)(100+percentage)/100);

                }

        }

        if (cardName == "Haste"){
            if (player != null)
                {
                    grassCollide = player.GetComponent<GrassCollide>();

                    grassCollide.reduceDeletion((float)(100-percentage)/100);

                }

        }

        if (cardName == "Powerup"){
            if (stats != null)
                {
                    statsObj = stats.GetComponent<Stats>();

                    statsObj.powerUp((float)(100+percentage)/100);

                    Debug.Log("Increased powerup by " + (float)(100+percentage)/100);

                }

        }

        // Example: if your game has a method to increase player health, call it here
        // Player.IncreaseHealth(healthBoostAmount);
    }

}
