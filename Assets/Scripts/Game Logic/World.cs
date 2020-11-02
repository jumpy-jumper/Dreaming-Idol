using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public string displayName;
    int actTime;
    public int tickRate;
    public bool IsTick { get => actTime % tickRate == 0; }
    public Sprite sprite;

    void Awake()
    {
        actTime = 0;
    }
    void Update()
    {
        actTime++;
    }

    public List<Enemy> encounters;
    public Enemy MakeEnemy()
    {
        Enemy ret = Instantiate(encounters[0]);

        ret.HP = ret.startingHP;
        ret.ATK = ret.startingATK;
        ret.DEF = ret.startingDEF;

        return ret;
    }
}
