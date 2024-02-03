using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDistance : MonoBehaviour
{
    private EnemyMove enemyMove;
    private Text text;

    private string dispText;
    private float distanceToPlayer;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
        if (text == null)
        {
            Debug.LogError("Text component not found on the GameObject.");
        }

        GameObject enemyGameObject = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyGameObject != null)
        {
            enemyMove = enemyGameObject.GetComponent<EnemyMove>();
            if (enemyMove == null)
            {
                Debug.LogError("EnemyMove component not found on the enemy GameObject.");
            }
        }
        else
        {
            Debug.LogError("Enemy GameObject not found.");
        }
    }

    void Update()
    {
        if (enemyMove != null)
        {
            distanceToPlayer = enemyMove.returnDist(); // Store the returned distance

            if (distanceToPlayer > 5)
            {
                text.enabled = true;
            }
            else if (distanceToPlayer < 4.9)
            {
                text.enabled = false;
            }
        }

        dispText = string.Format("{0:N0}", distanceToPlayer);

        text.text = (string)dispText + " CM"; 
    }

    public float returnDistance(){
        return distanceToPlayer;
    }
}
