using UnityEngine;

public class Crafter : Unit
{
    public override string GetClassName() { return "Crafter"; }
    public override Color GetClassColor() { return new Color(0.5f, 0.75f, 1); }
    public override string GetTopName() { return "Skill"; }
    public override string GetBotName() { return "Endurance"; }
    public override string GetTopAlias() { return "SKL"; }
    public override string GetBotAlias() { return "END"; }
}
