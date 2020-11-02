using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UnitList : MonoBehaviour
{
    public Player player;
    public Transform units;
    public List<UnitPanel> panels = new List<UnitPanel>();
    public UnitPanel template;
    public GameObject createUnitMenu;
    public UnitMenu inspectUnitMenu;

    public int horizontalSpacing;

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
