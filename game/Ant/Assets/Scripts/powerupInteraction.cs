using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class powerupInteraction : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public bool hasPowerup = false;
    public float powerupDuration = 5.0f;
    [SerializeField] private float powerupDur;
    GameObject speedObject;
    // Start is called before the first frame update

    public void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && hasPowerup)
        {
            applySpeedEffect();
            Invoke("stopSpeedEffect", powerupDuration);
            hasPowerup = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("speedPowerup"))
        {
            speedObject = other.gameObject;

            if (!hasPowerup)
            {
                Destroy(other.gameObject);
                hasPowerup = true;
            }

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

    public void updateDur(float durPercent){

        powerupDuration = powerupDuration * durPercent;
    }
    
}
