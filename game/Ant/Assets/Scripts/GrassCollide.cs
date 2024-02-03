using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class GrassCollide : MonoBehaviour
{
    GameObject grassObject;
    private float destroyTime = 0;
    public float deletionTimeThreshold = 3;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D other)
    {   
        // compares the object with the tag Grass
        if (other.CompareTag("Grass"))
        {
            // if the tag of the collision is grass, bol touch is true

            destroyTime += Time.deltaTime;
            grassObject = other.gameObject;
            // starts the timer for destruction
            if (destroyTime >= deletionTimeThreshold)
            {
                Destroy(grassObject);
                destroyTime = 0;
            }


        }
    }

    
    public void reduceDeletion(float deletionPercent){
        deletionTimeThreshold = deletionTimeThreshold * deletionPercent;
        Debug.Log("deletion time shortened");
    }



}
