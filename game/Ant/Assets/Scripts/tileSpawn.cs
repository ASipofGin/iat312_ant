using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tileSpawn : MonoBehaviour
{
    public GameObject[] tilesets;
    public GameObject tileSpawner;
    private bool spawnState = false;
    public float spawnCooldown = 0;
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

                int randomTileIndex = Random.Range(0, tilesets.Length);
                Instantiate(tilesets[randomTileIndex], new Vector3(transform.position.x + 50, 0, 0), transform.rotation);
                Instantiate(gameObject, new Vector3(transform.position.x + 50, 0, 0), transform.rotation);

            
        }
    }

}
