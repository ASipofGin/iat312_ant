using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float antlionSpdMult = 1f;

    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Prevent the music player from being destroyed on load

        // If there's already a music player in the scene, destroy this one to avoid duplicates
        if (FindObjectsOfType<Stats>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void antlionSpeedUp(){
        antlionSpdMult = antlionSpdMult * (float)1.2;
    }

    public float antLionSpeedMult(){
        return antlionSpdMult;
    }


}
