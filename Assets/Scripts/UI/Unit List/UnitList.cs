using System.Collections.Generic;
using UnityEngine;

/*
 * Uses player and unit information to build a unit list
 * with pre-spawned panels in the scene.
 * 
 * The unit list refreshes every frame.
 */

public class UnitList : MonoBehaviour
{
    [Header("World References")]
    public Player player;
    public Transform units;

    [Header("UI References")]
    public List<UnitPanel> panels = new List<UnitPanel>();

    void Update()
    {
        UpdateUnitList();
    }

    public void UpdateUnitList()
    {
        List<Unit> curUnits = new List<Unit>();
        foreach (Transform unit in units)
        {
            curUnits.Add(unit.GetComponent<Unit>());
        }

        int i = 0;
        foreach(UnitPanel panel in panels)
        {
            if (i >= player.maxUnits)
            {
                panel.gameObject.SetActive(false);
            }
            else
            {
                panel.gameObject.SetActive(true);
                if (i < curUnits.Count)
                {
                    panel.curUnit = curUnits[i];
                }
            }
            i++;
        }
    }
}
