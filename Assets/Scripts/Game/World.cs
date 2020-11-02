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
}
