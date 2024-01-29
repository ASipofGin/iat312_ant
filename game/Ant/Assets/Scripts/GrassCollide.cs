using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GrassCollide : MonoBehaviour
{
    private bool playerTouching = false;
    private float destroyTime = 0;
    public float deletionTimeThreshold = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTouching)
        {
            destroyTime += Time.deltaTime;

            if (destroyTime >= deletionTimeThreshold)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTouching = true;
            destroyTime = 0;
        }
    }




}
