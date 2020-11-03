using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

/*
 * A player has progress and customizations in the game.
 */

public class Player : MonoBehaviour
{
    public BigInteger newUnitPool = 500;
    public int hpMultiplier = 10;

    [Range(0, 7)] public int maxUnits = 1;
    public int maxUnitNameLength = 15;

    public List<World> discoveredWorlds = new List<World>();

    [Header("Text Settings")]
    public Font normalFont;
    public bool boldNormal;
    public Font monospacedFont;
    public bool boldMonospaced;
}
