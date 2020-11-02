using System.Collections.Generic;
using UnityEngine;

/*
 * A world is explorable by units and ticks periodically.
 */

public class World : MonoBehaviour
{
    public string displayName;
    public Sprite sprite;

    int actTime;
    public int tickRate;
    public bool IsTick { get => actTime % tickRate == 0; }

    void Awake()
    {
        actTime = 0;
    }

    void Update()
    {
        actTime++;
    }
}
