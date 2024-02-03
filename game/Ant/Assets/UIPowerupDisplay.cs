using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPowerupDisplay : MonoBehaviour
{
    public Image uiSpeedSprite;
    public Image uiHasteSprite;
    // Start is called before the first frame update
    void Start()
    {
        uiSpeedSprite = GetComponent<Image>();
        uiHasteSprite = GetComponent <Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
