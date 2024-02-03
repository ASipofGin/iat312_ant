using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tileSpawn : MonoBehaviour
{
    public GameObject[] tilesets;
    public GameObject[] anthillTiles;
    public GameObject tileSpawner;

    private bool spawnState = false;
    public float spawnCooldown = 0;
    public float stagesSpawned;
    [SerializeField] private Stats stats;
    [SerializeField] private float stageThreshold;
    public float stage = 0f;
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
        GameObject statsObj = GameObject.FindGameObjectWithTag("GameController");
        stats = statsObj.GetComponent<Stats>();
        stageThreshold = stats.threshHoldCount();
        stage = stats.stageCount();


        if (stage < stageThreshold)
        {
            if (other.CompareTag("Player") && !spawnState)
            {
                spawnState = true;

                stats.addStage();
                int randomTileIndex = UnityEngine.Random.Range(0, tilesets.Length);
                Instantiate(tilesets[randomTileIndex], new Vector3(transform.position.x + 60, 0, 0), transform.rotation);
                Instantiate(gameObject, new Vector3(transform.position.x + 60, 0, 0), transform.rotation);


            }
        }
        else if (stage >= stageThreshold)
        {
            if (other.CompareTag("Player") && !spawnState)
            {
                spawnState = true;
                Debug.Log(stage);
                Debug.Log(stageThreshold);
                stats.stageReset();
                stats.addThreshold();
                int randomTileIndex = UnityEngine.Random.Range(0, anthillTiles.Length);
                Instantiate(anthillTiles[randomTileIndex], new Vector3(transform.position.x + 60, 0, 0), transform.rotation);



            }
        }
    }

}
