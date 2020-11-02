using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleFileBrowser;

/*
 * Allows the player to create and summon a new unit.
 * Code is a mess since it's not really important.
 */

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
    public PromptManager prompts;
    public Transform unitToSummonContainer;

    [Header("Component References")]
    public UnitClassSelectionButtonGroup classButtonGroup;
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
        Clear();
    }

    void Clear()
    {
        unitToSummon = new GameObject().AddComponent<Fighter>();
        unitToSummon.transform.parent = unitToSummonContainer;
        introductoryExplanation.SetActive(true);
        image.sprite = defaultImage;
        nameField.Select();
        nameField.text = "";
        atkSlider.value = atkSlider.maxValue / 2f;
        classButtonGroup.Deselect();
    }

    public void Update()
    {
        unitToSummon.name = nameField.text;
        unitToSummon.avatar = image.sprite;

        unitToSummon.maxHp = player.newUnitPool * player.hpMultiplier;
        unitToSummon.top = player.newUnitPool * ((int)atkSlider.value * 10 / (int)atkSlider.maxValue) / 10;
        unitToSummon.bot = player.newUnitPool * ((int)defSlider.value * 10 / (int)defSlider.maxValue) / 10;

        atkNameplate.text = unitToSummon.GetTopAlias();
        defNameplate.text = unitToSummon.GetBotAlias();

        poolText.text = BigIntegerUtilities.ToString(player.newUnitPool, 5);
        hpText.text = BigIntegerUtilities.ToString(unitToSummon.maxHp, 5);
        atkText.text = BigIntegerUtilities.ToString(unitToSummon.top, 5);
        defText.text = BigIntegerUtilities.ToString(unitToSummon.bot, 5);
    }

    public void Summon()
    {
        bool valid = true;

        string text = "";
        if (units.transform.childCount >= player.maxUnits)
        {
            text += "You have the maximum number of units.\n";
            valid = false;
        }
        if (nameField.text.Length == 0)
        {
            text += "You have not named your unit.\n";
            valid = false;
        }
        else if (nameField.text.Length > player.maxUnitNameLength)
        {
            text += "Your unit's name is too long (max " + player.maxUnitNameLength + ").\n";
            valid = false;
        }
        if (image.sprite == defaultImage)
        {
            text += "You have not selected an image.\n";
            valid = false;
        }
        if (introductoryExplanation.activeSelf)
        {
            text += "You have not selected a class.\n";
            valid = false;
        }

        if (valid)
        {
            unitToSummon.transform.parent = units;
            unitToSummon.hp = unitToSummon.maxHp;
            Clear();
        }
        else
        {
            prompts.ShowNoticePrompt(text);
        }
    }

    public void ChangeUnitClass(string unitClass)
    {
        Unit newUnit = null;

        switch (unitClass)
        {
            case "Fighter":
                newUnit = new GameObject().AddComponent<Fighter>();
                break;
            case "Explorer":
                newUnit = new GameObject().AddComponent<Explorer>();
                break;
            case "Gatherer":
                newUnit = new GameObject().AddComponent<Gatherer>();
                break;
            case "Crafter":
                newUnit = new GameObject().AddComponent<Crafter>();
                break;
        }

        newUnit.transform.parent = unitToSummonContainer;
        Destroy(unitToSummon.gameObject);
        unitToSummon = newUnit;
    }

    public void ImportFromFile()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"));
        FileBrowser.SetDefaultFilter(".png");

        IEnumerator ShowLoadDialogCoroutine()
        {
            yield return FileBrowser.WaitForLoadDialog(false, true, null, "Load File", "Load");

            byte[] data = File.ReadAllBytes(FileBrowser.Result[0]);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(data);
            image.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }

        StartCoroutine(ShowLoadDialogCoroutine());
    }

    public void ImportFromWeb()
    {
        prompts.ShowInputPrompt("Enter URL...", OnOk);

        void OnOk()
        {
            StartCoroutine(LoadImage());

            IEnumerator LoadImage()
            {
                UnityWebRequest request = UnityWebRequestTexture.GetTexture(InputPrompt.input);
                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.LogError(request.error);
                }
                else
                {
                    Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
                    image.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                }
            }
        }
    }
}
