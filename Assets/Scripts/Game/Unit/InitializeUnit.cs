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
        unitComponent.maxHP = BigInteger.Parse(startingMaxHP);
        unitComponent.HP = BigInteger.Parse(startingHP);
        unitComponent.TOP = BigInteger.Parse(startingATK);
        unitComponent.BOT = BigInteger.Parse(startingDEF);
        unitComponent.EXP = BigInteger.Parse(startingEXP);
    }
}
