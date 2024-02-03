using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float antlionSpdMult = 1f;
    public float stgCount = 0;
<<<<<<< Updated upstream

    public float distance = 11;
=======
    public int anthillThreshold = 1;
>>>>>>> Stashed changes
    public int score;



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

    public void addStage()
    {
        stgCount += 1f;
    }
    public void addThreshold()
    {
        anthillThreshold += 1;
    }

    public void stageReset()
    {
        stgCount = 0f;
    }

    public float stageCount()
    {
        return stgCount;
    }

    public float threshHoldCount()
    {
        return anthillThreshold;
    }

    public void addScore(){
        score = score += 1;
    }

    public int getScore(){
        return score;
    }

    public void setDistance(float dist){
        distance = dist;
    }

    public float checkDistance(){
        return distance;
    }

    public float getOffset(){
        return distance;
    }


}
