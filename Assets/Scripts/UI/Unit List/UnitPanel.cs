using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

/*
 * Displays information for one unit.
 */

public class UnitPanel : MonoBehaviour
{
    [Header("World References")]
    public Unit curUnit;

    [Header("UI References")]
    public GameObject createUnitMenu;
    public UnitInspector inspectUnitMenu;

    [Header("Component References - Alive")]
    public CanvasGroup aliveUI;
    public Image avatar;
    public Slider health;
    public Image healthFill;
    public Text stats;

    [Header("Component References - Dead")]
    public CanvasGroup deadUI;
    public Image deadX;

    void Update()
    {
        if (!curUnit)
        {
            stats.gameObject.SetActive(false);
            avatar.gameObject.SetActive(false);
            health.gameObject.SetActive(false);
        }
        else
        {
            aliveUI.gameObject.SetActive(true);
            stats.gameObject.SetActive(true);

            int atkExp = (int)BigInteger.Log10(curUnit.top);
            int defExp = (int)BigInteger.Log10(curUnit.bot);
            stats.text = "";
            stats.text += curUnit.GetTopAlias() + " " + BigIntegerUtilities.ToString(curUnit.top, 5, 8);
            stats.text += "\n";
            stats.text += curUnit.GetBotAlias() + " " + BigIntegerUtilities.ToString(curUnit.bot, 5, 8);

            avatar.gameObject.SetActive(true);
            avatar.sprite = curUnit.avatar;

            health.gameObject.SetActive(true);
            health.value = curUnit.HPPercentage;
            healthFill.color = curUnit.GetClassColor();
        }
    }

    /*
     * Meant to listen to a Unity Event.
     * If the panel has a unit, shows the Unit Inspection menu for that unit.
     * Otherwise, shows the Unit Creation menu.
     */

    public void ShowUnitMenu()
    {
        if (!curUnit)
        {
            createUnitMenu.SetActive(true);
        }
        else
        {
            inspectUnitMenu.curUnit = curUnit;
            inspectUnitMenu.gameObject.SetActive(true);
        }
    }
}
