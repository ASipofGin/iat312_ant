using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class powerupSpawn : MonoBehaviour
{
    public GameObject[] powerups;
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
       if (powerups != null && powerups.Length > 0)
       {
          //spawnPowerup();
       }
    }

    private void spawnPowerup()
    {
       int randomIndex = UnityEngine.Random.Range(0, powerups.Length);

       Instantiate(powerups[randomIndex], new Vector3 (transform.position.x, transform.position.y, 0), quaternion.identity );
    }
  
}
