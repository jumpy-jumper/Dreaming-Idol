using UnityEngine;
using UnityEngine.UI;

public class WorldButton : MonoBehaviour
{
    [Header("World References")]
    public Player player;
    public World world;

    [Header("UI References")]
    public WorldInfoPanel worldInfoPanel;
    public Image worldImage;

    [Header("Resources")]
    public Sprite defaultImage;

    void Update()
    {
        if (world && player.discoveredWorlds.Contains(world))
        {
            worldImage.sprite = world.sprite;
        }
        else
        {
            worldImage.sprite = defaultImage;
        }
    }

    public void Select()
    {
        worldInfoPanel.curWorld = world;
    }
}
