using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupInteraction : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public bool hasPowerup = false;
    GameObject speedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("characterMovement");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("speedPowerup"))
        {
            speedObject = other.gameObject;

            if (!hasPowerup)
            {
                Destroy(other.gameObject);
                applySpeedEffect();
                hasPowerup = true;
            }

        }
    }

    public void applySpeedEffect()
    {
        GameObject player = GameObject.FindWithTag("Player");

        characterMovement = player.GetComponent<CharacterMovement>();

        characterMovement.addSpeed((float)1.20);
    }
}
