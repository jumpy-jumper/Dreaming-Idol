using UnityEngine;
using UnityEngine.UI;

/*
 * Asks the user to input some text.
 * The result is stored in the static string lastInput.
 * I have no idea what will happen if you have two input prompts active at once.
*/

public class InputPrompt : MonoBehaviour
{
    public static string lastInput = "";

    [Header("Component References")]
    public InputField inputField;
    public Button okButton;

    void Update()
    {
        lastInput = inputField.text;
    }

    void Start()
    {
        okButton.onClick.AddListener(delegate { Destroy(gameObject); });
    }
}
