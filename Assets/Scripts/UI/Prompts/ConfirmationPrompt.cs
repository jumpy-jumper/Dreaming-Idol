using UnityEngine;
using UnityEngine.UI;

/*
 * Asks the user a Yes / No question.
*/

public class ConfirmationPrompt : MonoBehaviour
{
    [Header("Component References")]
    public Text text;
    public Button yesButton;
    public Button noButton;

    void Start()
    {
        yesButton.onClick.AddListener(delegate { Destroy(gameObject); });
        noButton.onClick.AddListener(delegate { Destroy(gameObject); });
    }
}
