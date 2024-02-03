using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUUI : MonoBehaviour
{


    public Image PowerupBackground;
    public Image SpaceSprite;
    // Start is called before the first frame update
    void Start()
    {
        PowerupBackground = GameObject.FindWithTag("PUUI").GetComponent<Image>();
        SpaceSprite = GameObject.FindWithTag("Space").GetComponent<Image>();

        
        PowerupBackground.enabled = false;
        SpaceSprite.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // Check if the colliding object is the player
        {
            
            PowerupBackground.enabled = true;
            SpaceSprite.enabled = true;
        }
    }

}
