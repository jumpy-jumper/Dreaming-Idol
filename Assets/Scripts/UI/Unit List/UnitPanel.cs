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

            int atkExp = (int)BigInteger.Log10(curUnit.TOP);
            int defExp = (int)BigInteger.Log10(curUnit.BOT);
            int expPad = Mathf.Max((int)Mathf.Log10(atkExp), (int)Mathf.Log10(defExp)) + 1;
            stats.text = "";
            stats.text += curUnit.GetTopAlias() + " " + BigIntegerAdditions.ToString(curUnit.TOP, 5, 8, expPad);
            stats.text += "\n";
            stats.text += curUnit.GetBotAlias() + " " + BigIntegerAdditions.ToString(curUnit.BOT, 5, 8, expPad);

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
