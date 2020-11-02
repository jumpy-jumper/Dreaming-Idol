using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour
{
    public Color normal = Color.white;
    public List<Button> buttons = new List<Button>();

    public void Select(Button button)
    {
        foreach (Button b in buttons)
        {
            if (button == b)
            {
                ColorBlock cb = b.colors;
                cb.normalColor = cb.selectedColor;
                b.colors = cb;
            }
            else
            {
                ColorBlock cb = b.colors;
                cb.normalColor = Color.white;
                b.colors = cb;
            }
        }
    }

    public void Deselect()
    {
        foreach(Button b in buttons)
        {
            ColorBlock cb = b.colors;
            cb.normalColor = Color.white;
            b.colors = cb;
        }
    }
}

