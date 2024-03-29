using UnityEngine;
using UnityEngine.UI;

public class showSettings : MonoBehaviour
{
    public GameObject settingsImage; // Reference to your Instruction Image GameObject

    private void Start()
    {
        // Hide the Instruction Image at the start (optional, if it's not already hidden)
        settingsImage.SetActive(false);

        // Get the Button component on the element and add a click event listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ShowInstruction);
        }
    }

    private void ShowInstruction()
    {
        // Show the Instruction Image
        settingsImage.SetActive(true);
    }
}
