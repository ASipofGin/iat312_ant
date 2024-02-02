using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleInteraction : MonoBehaviour
{
    public CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Mud"))
        {
            GameObject player = GameObject.FindWithTag("Player");

            characterMovement = player.GetComponent<CharacterMovement>();
            characterMovement.addSpeed((float)0.5f);


        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Mud"))
        {
            Invoke("stopSlow", 0.5f); ;


        }
    }

    public void stopSlow()
    {

        GameObject player = GameObject.FindWithTag("Player");

        characterMovement = player.GetComponent<CharacterMovement>();

        characterMovement.addSpeed((float)2);
    }
}
