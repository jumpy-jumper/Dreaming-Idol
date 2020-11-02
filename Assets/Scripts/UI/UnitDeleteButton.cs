using UnityEngine;
using UnityEngine.UI;

public class UnitDeleteButton : MonoBehaviour
{
    public UnitMenu unitMenu;

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
