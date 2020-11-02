using UnityEngine;
using System.Numerics;

public class InitializeUnit : MonoBehaviour
{
    Unit unitComponent;

    public string startingMaxHP;
    public string startingHP;
    public string startingATK;
    public string startingDEF;

    void Start()
    {
        unitComponent = GetComponent<Unit>();
        unitComponent.maxHP = BigInteger.Parse(startingMaxHP);
        unitComponent.HP = BigInteger.Parse(startingHP);
        unitComponent.ATK = BigInteger.Parse(startingATK);
        unitComponent.DEF = BigInteger.Parse(startingDEF);
    }
}
