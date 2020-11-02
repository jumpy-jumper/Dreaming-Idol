using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using System.IO;

public class UnitCreationMenu : MonoBehaviour
{

    Unit unitToSummon;

    [Header("Defaults")]
    public Sprite defaultImage;

    [Header("World References")]
    public Player player;
    public Transform units;

    [Header("UI References")]
    public GameObject introductoryExplanation;
    public InputField nameField;
    public Image image;
    public GameObject noticePrompt;
    public Text noticePromptText;
    public GameObject inputPrompt;
    public Text inputPromptText;

    [Header("Component References")]
    public ButtonGroup classButtons;
    public Text atkNameplate;
    public Text defNameplate;
    public Text poolText;
    public Text hpText;
    public Text atkText;
    public Text defText;
    public Slider atkSlider;
    public Slider defSlider;

    void Awake()
    {
        unitToSummon = Instantiate(new GameObject().AddComponent<Unit>());
        unitToSummon.name = "Unit To Summon";
    }

    public void Summon()
    {
        bool valid = true;

        noticePromptText.text = "";
        if (units.transform.childCount >= player.maxUnits)
        {
            noticePromptText.text += "You have the maximum number of units.\n";
            valid = false;
        }
        if (nameField.text.Length == 0)
        {
            noticePromptText.text += "You have not named your unit.\n";
            valid = false;
        }
        else if (nameField.text.Length > player.maxUnitNameLength)
        {
            noticePromptText.text += "Your unit's name is too long (max " + player.maxUnitNameLength + ").\n";
            valid = false;
        }
        if (image.sprite == defaultImage)
        {
            noticePromptText.text += "You have not selected an image.\n";
            valid = false;
        }
        if (introductoryExplanation.activeSelf)
        {
            noticePromptText.text += "You have not selected a class.\n";
            valid = false;
        }

        if (valid)
        {
            unitToSummon.transform.parent = units;
            unitToSummon.name = nameField.text;
            unitToSummon.avatar = image.sprite;
            unitToSummon.HP = unitToSummon.maxHP;
            Clear();
        }
        else
        {
            noticePrompt.SetActive(true);
        }
    }

    void Clear()
    {
        unitToSummon = Instantiate(new GameObject().AddComponent<Unit>());
        introductoryExplanation.SetActive(true);
        image.sprite = defaultImage;
        nameField.Select();
        nameField.text = "";
        atkSlider.value = atkSlider.maxValue / 2f;
        classButtons.Deselect();
    }

    public void Update()
    {
        unitToSummon.maxHP = player.newUnitPool * player.hpFromPool;
        unitToSummon.TOP = player.newUnitPool * ((int)atkSlider.value * 10 / (int)atkSlider.maxValue) / 10;
        unitToSummon.BOT = player.newUnitPool * ((int)defSlider.value * 10 / (int)defSlider.maxValue) / 10;

        atkNameplate.text = unitToSummon.GetTopAlias();
        defNameplate.text = unitToSummon.GetBotAlias();

        poolText.text = BigIntegerAdditions.ToString(player.newUnitPool, 5);
        hpText.text = BigIntegerAdditions.ToString(unitToSummon.maxHP, 5);
        atkText.text = BigIntegerAdditions.ToString(unitToSummon.TOP, 5);
        defText.text = BigIntegerAdditions.ToString(unitToSummon.BOT, 5);
    }

    public void ChangeClass(int type)
    {
        // unitToSummon.unitClass = (Unit.UnitClass)type;
    }

    public void ImportFromFile()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"));
        FileBrowser.SetDefaultFilter(".png");
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(false, true, null, "Load File", "Load");

        byte[] data = File.ReadAllBytes(FileBrowser.Result[0]);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(data);
        image.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    }

    public void ImportFromWeb()
    {
    }
}
