using UnityEngine;
using UnityEngine.UI;

public class UnitMenu : MonoBehaviour
{
    [Header("World References")]
    public Unit curUnit;

    [Header("Scene References")]
    public Text nameText;
    public Image avatar;
    public Text classText;
    public Text atkNameplate;
    public Text defNameplate;
    public Text maxHpValue;
    public Text hpValue;
    public Text atkValue;
    public Text defValue;
    public Text expValue;

    public GameObject deployed;
    public GameObject notDeployed;
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
            nameText.color = curUnit.GetColor();
            avatar.sprite = curUnit.avatar;
            classText.text = curUnit.GetClass().ToUpper();
            classText.color = curUnit.GetColor();
            atkNameplate.text = curUnit.GetAtkAlias();
            defNameplate.text = curUnit.GetDefAlias();
            maxHpValue.text = BigIntegerAdditions.ToString(curUnit.maxHP, 8);
            hpValue.text = BigIntegerAdditions.ToString(curUnit.HP, 8);
            atkValue.text = BigIntegerAdditions.ToString(curUnit.ATK, 8);
            defValue.text = BigIntegerAdditions.ToString(curUnit.DEF, 8);
            expValue.text = BigIntegerAdditions.ToString(curUnit.EXP, 8);

            if (curUnit.curWorld)
            {
                notDeployed.gameObject.SetActive(false);
                deployed.gameObject.SetActive(true);
                worldText.text = curUnit.curWorld.displayName;
                worldImage.sprite = curUnit.curWorld.sprite;
                worldImage.gameObject.SetActive(true);
                floorText.text = "F" + BigIntegerAdditions.ToString(curUnit.curFloor, 8);
                floorText.gameObject.SetActive(true);
            }
            else
            {
                deployed.gameObject.SetActive(false);
                notDeployed.gameObject.SetActive(true);
                worldImage.gameObject.SetActive(false);
                floorText.gameObject.SetActive(false);
            }
        }
    }
}
