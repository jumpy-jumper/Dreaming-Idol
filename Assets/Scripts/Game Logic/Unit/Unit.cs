using System.Numerics;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Type { Fighter, Explorer, Gatherer, Crafter }
    public Type type;

    public Sprite avatar;

    public BigInteger maxHP;
    public BigInteger HP;
    public float HPPercentage { get => (float)(HP * 100 / maxHP) / 100; }
    public BigInteger ATK;
    public BigInteger DEF;
    public BigInteger EXP;

    public bool alive{ get => HP > 0; }

    public World curWorld;
    public BigInteger curFloor;

    void Start()
    {
        HP = BigInteger.Min(HP, maxHP);
        EXP = 0;
        curFloor = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            HP = 0;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ATK += BigInteger.Pow(10, 10);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            DEF += BigInteger.Pow(10, 10);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            curFloor ++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            curFloor += BigInteger.Pow(10, 100);
        }
    }

    void Fight(Enemy enemy)
    {
        BigInteger dmg;

        if (ATK <= enemy.DEF)
        {
            HP = 0;
        }
        else if (enemy.ATK > DEF)
        {
            dmg = (enemy.ATK - DEF) * (enemy.HP / (ATK - enemy.DEF));
            HP = BigInteger.Max(HP - dmg, 0);
        }

        Destroy(enemy);
    }

    public string GetClass()
    {
        switch (type)
        {
            case Unit.Type.Fighter:
                return "Fighter";
            case Unit.Type.Explorer:
                return "Explorer";
            case Unit.Type.Crafter:
                return "Crafter";
            case Unit.Type.Gatherer:
                return "Gatherer";
        }

        return "NULL";
    }

    public Color GetColor()
    {
        switch (type)
        {
            case Unit.Type.Fighter:
                return new Color(1, 0.5f, 0.5f);
            case Unit.Type.Explorer:
                return new Color(1, 1, 0.5f);
            case Unit.Type.Crafter:
                return new Color(0.5f, 0.75f, 1);
            case Unit.Type.Gatherer:
                return new Color(0.75f, 1, 0.5f);
        }

        return Color.black;
    }

    public string GetAtkAlias()
    {
        switch (type)
        {
            case Unit.Type.Fighter:
                return "ATK";
            case Unit.Type.Explorer:
                return "BRV";
            case Unit.Type.Gatherer:
                return "PER";
            case Unit.Type.Crafter:
                return "SKL";
        }

        return "";
    }

    public string GetDefAlias()
    {
        switch (type)
        {
            case Unit.Type.Fighter:
                return "DEF";
            case Unit.Type.Explorer:
                return "DET";
            case Unit.Type.Gatherer:
                return "FOR";
            case Unit.Type.Crafter:
                return "END";
        }

        return "";
    }
}
