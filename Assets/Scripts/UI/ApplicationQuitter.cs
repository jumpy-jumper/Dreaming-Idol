using UnityEngine;
using UnityEngine.UI;

public class ApplicationQuitter : MonoBehaviour
{
    public GameObject prompt;
    public Text text;
    public Button yes;

    public void QuitPrompt()
    {
        text.text = "Quit the game?";
        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener(Application.Quit);
        prompt.SetActive(true);
    }
}
