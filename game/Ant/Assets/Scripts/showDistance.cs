using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDistance : MonoBehaviour
{
    private EnemyMove enemyMove;
    private Text text;
    private Image image;

    private string dispText;
    private float distanceToPlayer;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
        image = gameObject.GetComponentInChildren<Image>();

        if (text == null && image == null)
        {
            Debug.LogError("Text or image component not found on the GameObject.");
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
                image.enabled = true;
            }
            else if (distanceToPlayer < 4.9)
            {
                text.enabled = false;
                image.enabled = false;
            }
        }

        dispText = string.Format("{0:N0}", distanceToPlayer);

        text.text = (string)dispText + " CM away from antlion"; 
    }

    public float returnDistance(){
        return distanceToPlayer;
    }
}
