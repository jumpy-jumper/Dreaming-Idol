using UnityEngine;
using UnityEngine.UI;

/*
 * Allows the user to destroy a unit's game object.
 */

public class UnitDeleteButton : MonoBehaviour
{
    public UnitInspector unitMenu;

    public GameObject prompt;
    public Text text;
    public Button yes;

    Unit unitToDelete;

    public void DeletePrompt()
    {
        unitToDelete = unitMenu.curUnit;
        text.text = "Delete " + unitToDelete.name + "?";

        yes.onClick.RemoveAllListeners();
        yes.onClick.AddListener(DeleteUnit);

        prompt.SetActive(true);
    }

    void DeleteUnit()
    {
        Destroy(unitToDelete.gameObject);
        prompt.SetActive(false);
    }
}
