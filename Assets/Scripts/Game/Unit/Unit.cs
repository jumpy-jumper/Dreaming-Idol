using System.Numerics;
using UnityEngine;

/*
 * An individual unit in the game world.
 * The Unit class enforces the following design.
 *      There are five stats - Max HP, HP, TOP, BOT, and EXP
 *      TOP and BOT are the two main stats, their names differ depending on the class
 * The Unit class must be inherited from depending on the unit's base class
 */

public abstract class Unit : MonoBehaviour
{
    public Sprite avatar;

    public BigInteger maxHp;
    public BigInteger hp;
    public bool Alive { get => hp > 0; }
    public float HPPercentage { get => (float)(hp * 1000 / maxHp) / 1000; }

    public BigInteger top;
    public BigInteger bot;

    public BigInteger exp;

    public World curWorld;
    public BigInteger curFloor;

    // Class-Based Definitions

    public abstract string GetClassName();
    public abstract Color GetClassColor();
    public abstract string GetTopName();
    public abstract string GetBotName();
    public abstract string GetTopAlias();
    public abstract string GetBotAlias();
}
