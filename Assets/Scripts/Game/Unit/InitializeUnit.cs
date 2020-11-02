using System.Numerics;
using UnityEngine;

/*
 * Allows for easy unit initialization from the inspector.
 */

[RequireComponent(typeof(Unit))]
public class InitializeUnit : MonoBehaviour
{
    [Header("Inspector Variables")]
    public string startingMaxHP;
    public string startingHP;
    public string startingATK;
    public string startingDEF;
    public string startingEXP;

    [Header("Component References")]
    Unit unitComponent;

    void Start()
    {
        unitComponent = GetComponent<Unit>();
        unitComponent.maxHp = BigInteger.Parse(startingMaxHP);
        unitComponent.hp = BigInteger.Parse(startingHP);
        unitComponent.top = BigInteger.Parse(startingATK);
        unitComponent.bot = BigInteger.Parse(startingDEF);
        unitComponent.exp = BigInteger.Parse(startingEXP);
    }
}
