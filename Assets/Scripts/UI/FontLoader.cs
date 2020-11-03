using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Changes fonts of specified Text to a Player's preferred fonts.
 * 
 * This runs through the entire hierarchy every frame,
 * which is obviously awful.
 * 
 * It will break if the player assigns the same font for both monospaced
 * and normal text.
 */

public class FontLoader : MonoBehaviour
{
    public Player player;
    public Font defaultNormalFont;
    public Font defaultMonospacedFont;

    List<Text> normalText = new List<Text>();
    List<Text> monospacedText = new List<Text>();

    void Update()
    {
        Text[] allText = FindObjectsOfType<Text>();
        foreach (Text text in allText)
        {
            if (text.font == defaultNormalFont)
            {
                normalText.Add(text);
            }
            else if (text.font == defaultMonospacedFont)
            {
                monospacedText.Add(text);
            }
        }

        foreach (Text text in normalText)
        {
            if (text)
            {
                if (player.normalFont)
                {
                    text.font = player.normalFont;
                }
                
                text.fontStyle = player.boldNormal ? FontStyle.Bold : FontStyle.Normal;
            }
        }

        foreach (Text text in monospacedText)
        {
            if (text)
            {
                if (player.monospacedFont)
                {
                    text.font = player.monospacedFont;
                }

                text.fontStyle = player.boldMonospaced ? FontStyle.Bold : FontStyle.Normal;
            }
        }
    }
}
