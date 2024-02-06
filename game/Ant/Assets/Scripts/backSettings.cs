using UnityEngine;
using UnityEngine.UI;

public class BackSettings : MonoBehaviour
{
    public GameObject settingsImage; // Reference to your Instruction Image GameObject

    private void Start()
    {
        // Get the Button component on the element and add a click event listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(removeSettings);
        }
    }

    private void removeSettings()
    {
        // Show the Instruction Image
        settingsImage.SetActive(false);
    }
}
