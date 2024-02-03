using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInteraction : MonoBehaviour
{
    public CharacterMovement characterMovement;
    private bool isSlowed = false; // flag to track if the player is already slowed

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mud") && !isSlowed)
        {
            isSlowed = true;
            GameObject player = GameObject.FindWithTag("Player");

            characterMovement = player.GetComponent<CharacterMovement>();
            characterMovement.addSpeed((float)0.5f);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Mud") && isSlowed)
        {
            isSlowed = false;
            Invoke("StopSlow", 0.5f);
        }
    }

    public void StopSlow()
    {
        GameObject player = GameObject.FindWithTag("Player");

        characterMovement = player.GetComponent<CharacterMovement>();
        characterMovement.addSpeed((float)2);
    }
}
