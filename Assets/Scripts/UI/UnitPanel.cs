using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class UnitPanel : MonoBehaviour
{
    [Header("World References")]
    public Unit curUnit;

    [Header("Component References")]
    public Image avatar;
    public Slider health;
    public Image healthFill;
    public Text stats;
    public CanvasGroup alive;
    public CanvasGroup dead;
    public Image deadX;

    [Header("Scene References")]
    public GameObject createUnitMenu;
    public UnitMenu inspectUnitMenu;

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
            alive.gameObject.SetActive(true);
            stats.gameObject.SetActive(true);

            int atkExp = (int)BigInteger.Log10(curUnit.ATK);
            int defExp = (int)BigInteger.Log10(curUnit.DEF);
            int expPad = Mathf.Max((int)Mathf.Log10(atkExp), (int)Mathf.Log10(defExp)) + 1;
            stats.text = "";
            stats.text += curUnit.GetAtkAlias() + " " + BigIntegerAdditions.ToString(curUnit.ATK, 5, 8, expPad);
            stats.text += "\n";
            stats.text += curUnit.GetDefAlias() + " " + BigIntegerAdditions.ToString(curUnit.DEF, 5, 8, expPad);

            avatar.gameObject.SetActive(true);
            avatar.sprite = curUnit.avatar;

            health.gameObject.SetActive(true);
            health.value = curUnit.HPPercentage;
            healthFill.color = curUnit.GetColor();

            dead.gameObject.SetActive(!curUnit.alive);
            deadX.color = curUnit.GetColor();
        }
    }

    public void LoadUnitMenu()
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
