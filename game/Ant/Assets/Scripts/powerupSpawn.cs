using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine;

public class powerupSpawn : MonoBehaviour
{
    public GameObject[] powerups;

    public int powerupSpawnRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       

    private void OnDestroy()
    {
        if (!SceneManager.GetActiveScene().isLoaded)
        {
            // The scene is unloading, so don't spawn the power-up
            return;
        }

        if (powerups != null && powerups.Length > 0)
        {
            int spawnChance = UnityEngine.Random.Range(0, 100);

            if (spawnChance <= powerupSpawnRate)
            {
                spawnPowerup();
            }
        }
    
       
    }

    private void spawnPowerup()
    {
       int randomIndex = UnityEngine.Random.Range(0, powerups.Length);

       Instantiate(powerups[randomIndex], new Vector3 (transform.position.x, transform.position.y -0.5f, 0), quaternion.identity );
    }
    

}
