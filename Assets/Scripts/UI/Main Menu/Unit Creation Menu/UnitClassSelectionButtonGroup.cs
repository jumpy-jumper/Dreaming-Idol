using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Changes the normal colors of a button if it was last selected in the group.
 * Workaround to the button deselecting itself.
 */

public class UnitClassSelectionButtonGroup : MonoBehaviour
{
    [Header("Scene References")]
    public Button fighterButton;
    public Button explorerButton;
    public Button gathererButton;
    public Button crafterButton;

    [Header("Data")]
    public List<Button> buttons;
    public Button selected;

    void Awake()
    {
        buttons.Add(fighterButton);
        buttons.Add(explorerButton);
        buttons.Add(gathererButton);
        buttons.Add(crafterButton);
    }

    void Update()
    {
        foreach(Button button in buttons)
        {
            if (button == selected)
            {
                ColorBlock cb = button.colors;
                cb.normalColor = cb.selectedColor;
                button.colors = cb;
            }
            else
            {
                ColorBlock cb = button.colors;
                cb.normalColor = Color.white;
                button.colors = cb;
            }
        }
    }

    public void Select(Button button)
    {
        selected = button;
    }

    public void Deselect()
    {
        selected = null;
    }
}
