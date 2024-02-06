using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class powerupInteraction : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public GrassCollide grassCollide;


    public UIPowerupDisplay uiPowerupDisplay;
    
    public bool hasPowerup = false;
    public bool hasSpeed = false;
    public bool hasHaste = false;
    public float powerupDuration = 5.0f;
    [SerializeField] private Stats stats;
    [SerializeField] private float powerupDur;
    GameObject speedObject;
    GameObject hasteObject;


    // Start is called before the first frame update

    public void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Try to find the uiPowerupDisplayObj every time a new scene is loaded
        GameObject uiPowerupDisplayObj = GameObject.FindGameObjectWithTag("PowerupUI");
        if (uiPowerupDisplayObj != null) 
        {
            uiPowerupDisplay = uiPowerupDisplayObj.GetComponent<UIPowerupDisplay>();
        }
        else
        {
            uiPowerupDisplay = null; // If the object is not found, set it to null
        }
    }

     void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe when the object is destroyed
    }
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject uiPowerupDisplayObj = GameObject.FindGameObjectWithTag("PowerupUI");
        uiPowerupDisplay = uiPowerupDisplayObj.GetComponent<UIPowerupDisplay>();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && hasSpeed)
        {
            applySpeedEffect();
            Invoke("stopSpeedEffect", powerupDuration);
            hasPowerup = false;
            hasSpeed = false;

            //GameObject uiSpeed = GameObject.FindWithTag("SpeedUIElement");

            //uiPowerupDisplay = uiSpeed.GetComponent<UIPowerupDisplay>();



            uiPowerupDisplay.hideSpeedUI();

        }

        else if (Input.GetKeyDown(KeyCode.Space) == true && hasHaste)
        {
            applyHasteEffect();
            Invoke("stopHasteEffect", powerupDuration);
            hasPowerup = false;
            hasHaste = false;

           // GameObject uiHaste = GameObject.FindWithTag("HasteUIElement");

            //uiPowerupDisplay = uiHaste.GetComponent<UIPowerupDisplay>();

            uiPowerupDisplay.hideHasteUI();

        }

        if (hasSpeed)
        {
            uiPowerupDisplay.showSpeedUI();
            uiPowerupDisplay.hideHasteUI();
        }

        else if (hasHaste)
        {
            uiPowerupDisplay.showHasteUI();
            uiPowerupDisplay.hideSpeedUI();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("speedPowerup") && !hasPowerup)
        {
            speedObject = other.gameObject;
            Destroy(other.gameObject);
            hasPowerup = true;
            hasSpeed = true;
            hasHaste = false;

            uiPowerupDisplay.hideHasteUI();
            uiPowerupDisplay.showSpeedUI();



        }

        else if (other.CompareTag("hastePowerup") && !hasPowerup)
        {
            hasteObject = other.gameObject;
            Destroy(other.gameObject);
            hasPowerup = true;
            hasHaste = true;
            hasSpeed = false;

            uiPowerupDisplay.showHasteUI();
            uiPowerupDisplay.hideSpeedUI();


        }
    }

    public void applySpeedEffect()
    {

        GameObject player = GameObject.FindWithTag("Player");

        characterMovement = player.GetComponent<CharacterMovement>();

        characterMovement.addSpeed((float)1.20);
    }


    public void stopSpeedEffect()
    {
        GameObject player = GameObject.FindWithTag("Player");

        characterMovement = player.GetComponent<CharacterMovement>();

        characterMovement.removeSpeed((float)1.20);
    }

    public void applyHasteEffect()
    {

        GameObject player = GameObject.FindWithTag("Player");

        grassCollide = player.GetComponent<GrassCollide>();

        grassCollide.reduceDeletion((float)(100 - 20) / 100);
    }

    public void stopHasteEffect()
    {
        GameObject player = GameObject.FindWithTag("Player");

        grassCollide = player.GetComponent<GrassCollide>();

        grassCollide.reduceDeletion((float)(100 + 25) / 100);
    }

    public void updateDur(float durPercent)
    {

        powerupDuration = powerupDuration * durPercent;
    }
}

