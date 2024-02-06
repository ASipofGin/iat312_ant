using UnityEngine;
using UnityEngine.UI;

public class BackInstuction : MonoBehaviour
{
    public GameObject instructionImage; // Reference to your Instruction Image GameObject

    private void Start()
    {
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
        instructionImage.SetActive(false);
    }
}
