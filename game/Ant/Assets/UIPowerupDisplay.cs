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
        uiSpeedSprite = GameObject.FindWithTag("SpeedUIElement").GetComponent<Image>();
        uiHasteSprite = GameObject.FindWithTag("HasteUIElement").GetComponent<Image>();


        uiSpeedSprite.enabled = false;
        uiHasteSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showSpeedUI()
    {
        uiSpeedSprite.enabled = true;
    }

    public void showHasteUI()
    {
        uiHasteSprite.enabled = true;
    }

    public void hideSpeedUI()
    {
        uiSpeedSprite.enabled = false;
    }

    public void hideHasteUI()
    {
        uiHasteSprite.enabled = false;
    }
}
