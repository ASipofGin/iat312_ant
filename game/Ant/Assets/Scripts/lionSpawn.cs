using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lionpawn : MonoBehaviour
{
    private bool spawnState = false;
    public float spawnCooldown = 0;

    public GameObject AntLion;

    public GameObject DistanceCounter;
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
        Debug.Log("Spawned");
        if (other.CompareTag("Player") && !spawnState)
        {
                spawnState = true;

                AntLion.SetActive(true);
                DistanceCounter.SetActive(true);



            
        }
    }

}
