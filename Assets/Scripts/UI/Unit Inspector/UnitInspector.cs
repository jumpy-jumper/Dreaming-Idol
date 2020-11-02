using UnityEngine;
using UnityEngine.UI;

/*
 * Menu that shows detailed information about one unit.
 * 
 * If a unit has not been assigned, immediately deactivates itself.
 */

public class UnitInspector : MonoBehaviour
{
    [Header("World References")]
    public Unit curUnit;

    [Header("Scene References")]
    // Basic Information
    public Text nameText;
    public Image avatar;
    public Text classText;

    // Stats Information
    public Text atkNameplate;
    public Text defNameplate;
    public Text maxHpValue;
    public Text hpValue;
    public Text atkValue;
    public Text defValue;
    public Text expValue;

    // World Information
    public GameObject deployedUI;
    public GameObject notDeployedUI;
    public Text worldText;
    public Image worldImage;
    public Text floorText;

    void Update()
    {
        if (!curUnit)
        {
            gameObject.SetActive(false);
        }
        else
        {
            nameText.text = curUnit.name;
            nameText.color = curUnit.GetClassColor();
            avatar.sprite = curUnit.avatar;
            classText.text = curUnit.GetClassName().ToUpper();
            classText.color = curUnit.GetClassColor();
            atkNameplate.text = curUnit.GetTopAlias();
            defNameplate.text = curUnit.GetBotAlias();
            maxHpValue.text = BigIntegerAdditions.ToString(curUnit.maxHP, 8);
            hpValue.text = BigIntegerAdditions.ToString(curUnit.HP, 8);
            atkValue.text = BigIntegerAdditions.ToString(curUnit.TOP, 8);
            defValue.text = BigIntegerAdditions.ToString(curUnit.BOT, 8);
            expValue.text = BigIntegerAdditions.ToString(curUnit.EXP, 8);

            if (curUnit.curWorld)
            {
                notDeployedUI.gameObject.SetActive(false);
                deployedUI.gameObject.SetActive(true);
                worldText.text = curUnit.curWorld.displayName;
                worldImage.sprite = curUnit.curWorld.sprite;
                worldImage.gameObject.SetActive(true);
                floorText.text = "F" + BigIntegerAdditions.ToString(curUnit.curFloor, 8);
                floorText.gameObject.SetActive(true);
            }
            else
            {
                deployedUI.gameObject.SetActive(false);
                notDeployedUI.gameObject.SetActive(true);
                worldImage.gameObject.SetActive(false);
                floorText.gameObject.SetActive(false);
            }
        }
    }
}
