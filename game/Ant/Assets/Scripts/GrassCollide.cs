using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GrassCollide : MonoBehaviour
{
    private bool grassTouching = false;
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
        if (grassTouching)
        {
            destroyTime += Time.deltaTime;

            if (destroyTime >= deletionTimeThreshold)
            {
                Destroy(grassObject);

            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {   
        // compares the object with the tag Grass
        if (other.CompareTag("Grass"))
        {
            // if the tag of the collision is grass, bol touch is true
            Debug.Log("touching");
            grassTouching = true;
            grassObject = other.gameObject;
            // starts the timer for destruction
            destroyTime = 0;

            
        }
    }



}
