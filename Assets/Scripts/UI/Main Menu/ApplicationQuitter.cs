using UnityEngine;
using UnityEngine.UI;

public class ApplicationQuitter : MonoBehaviour
{
    public PromptCanvas promptCanvas;

    public void QuitPrompt()
    {
        promptCanvas.ShowConfirmationPrompt("Quit the game?", delegate { Application.Quit(); });
    }
}
