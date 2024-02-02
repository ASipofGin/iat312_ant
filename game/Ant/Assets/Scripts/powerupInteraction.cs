using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class powerupInteraction : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public GrassCollide grassCollide;
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

    }
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
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
        }

        else if (Input.GetKeyDown(KeyCode.Space) == true && hasHaste)
        {
            applyHasteEffect();
            Invoke("stopHasteEffect", powerupDuration);
            hasPowerup = false;
            hasHaste = false;
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
        }

        else if (other.CompareTag("hastePowerup") && !hasPowerup)
        {
            hasteObject = other.gameObject;
            Destroy(other.gameObject);
            hasPowerup = true;
            hasHaste = true;
            hasSpeed = false;

        }
    }

    public void applySpeedEffect()
    {

        GameObject player = GameObject.FindWithTag("Player");

        characterMovement = player.GetComponent<CharacterMovement>();

        characterMovement.addSpeed((float)1.10);
    }


    public void stopSpeedEffect()
    {
        GameObject player = GameObject.FindWithTag("Player");

        characterMovement = player.GetComponent<CharacterMovement>();

        characterMovement.addSpeed((float)0.91);
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

