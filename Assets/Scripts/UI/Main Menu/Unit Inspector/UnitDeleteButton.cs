using UnityEngine;
using UnityEngine.UI;

/*
 * Allows the user to destroy a unit's game object.
 */

public class UnitDeleteButton : MonoBehaviour
{
    public UnitInspector unitMenu;
    public PromptCanvas promptCanvas;

    public void DeletePrompt()
    {
        promptCanvas.ShowConfirmationPrompt("Delete " + unitMenu.curUnit.name + "?", delegate { Destroy(unitMenu.curUnit.gameObject); } );
    }
}
