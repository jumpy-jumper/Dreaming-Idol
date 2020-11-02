using UnityEngine;
using UnityEngine.UI;

/*
 * Asks the user to input some text.
 * The result is stored in the static string 'input'.
 * I have no idea what will happen if you have two input prompts active at once.
*/

public class InputPrompt : MonoBehaviour
{
    public static string input = "";

    [Header("Component References")]
    public InputField inputField;
    public Button okButton;
    public Button cancelButton;

    void Update()
    {
        input = inputField.text;
    }

    void Start()
    {
        okButton.onClick.AddListener(delegate { Destroy(gameObject); });
        cancelButton.onClick.AddListener(delegate { Destroy(gameObject); });
    }
}
