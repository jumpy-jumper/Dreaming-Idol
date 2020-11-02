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

    public int maxUnits = 1;
    public int maxUnitNameLength = 15;

    public List<World> discoveredWorlds = new List<World>();
}
