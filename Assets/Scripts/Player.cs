using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<World> discoveredWorlds = new List<World>();
    public int maxUnitNameLength = 15;
    public BigInteger newUnitPool = 500;
    public int hpFromPool = 10;
    public int maxUnits;
}
