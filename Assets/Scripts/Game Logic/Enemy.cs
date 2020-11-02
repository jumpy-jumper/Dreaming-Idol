using System.Numerics;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public int startingPlus;
    public int startingLevel;
    public int startingHP;
    public int startingATK;
    public int startingDEF;

    public BigInteger plus;
    public BigInteger level;
    public BigInteger HP;
    public BigInteger ATK;
    public BigInteger DEF;
}
