using UnityEngine;
using UnityEngine.UI;

/*
 * Allows the user to destroy a unit's game object.
 */

public class UnitDeleteButton : MonoBehaviour
{
    public UnitInspector unitMenu;
    public PromptManager promptManager;

    public void DeletePrompt()
    {
        promptManager.ShowConfirmationPrompt("Delete " + unitMenu.curUnit.name + "?", delegate { Destroy(unitMenu.curUnit.gameObject); } );
    }
}
