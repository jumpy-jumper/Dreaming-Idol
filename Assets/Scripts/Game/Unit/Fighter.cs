using UnityEngine;

public class Fighter : Unit
{
    public override string GetClassName() { return "Fighter"; }
    public override Color GetClassColor() { return new Color(1, 0.5f, 0.5f); }
    public override string GetTopName() { return "Attack"; }
    public override string GetBotName() { return "Defense"; }
    public override string GetTopAlias() { return "ATK"; }
    public override string GetBotAlias() { return "DEF"; }
}
