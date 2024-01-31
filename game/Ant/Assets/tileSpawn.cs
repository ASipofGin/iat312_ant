using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSpawn : MonoBehaviour
{
    public GameObject[] tilesets;
    public float spawnTimer = 30;
    public float spawnCooldown = 0;
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
        Debug.Log("Spawned");
        if (other.CompareTag("Player"))
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= spawnCooldown)
            {
                spawnTimer = 30;
                int randomTileIndex = Random.Range(0, tilesets.Length);
                Instantiate(tilesets[randomTileIndex], new Vector3(transform.position.x + 50, transform.position.y, 0), transform.rotation);
            }
        }
    }
}
