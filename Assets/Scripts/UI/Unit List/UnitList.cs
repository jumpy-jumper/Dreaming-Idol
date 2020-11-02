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
    public Transform panels;

    /*
     * The Update method calls GetComponent twice per unit,
     * but because there may only be one UnitList at a time,
     * this is not a big performance hit.
     * 
     * This is also the simplest way to architecture this functionality.
     */
    void Update()
    {
        List<Unit> curUnits = new List<Unit>();
        foreach (Transform unit in units)
        {
            curUnits.Add(unit.GetComponent<Unit>());
        }

        int i = 0;
        foreach (Transform panel in panels)
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
                    panel.GetComponent<UnitPanel>().curUnit = curUnits[i];
                }
            }
            i++;
        }
    }
}
