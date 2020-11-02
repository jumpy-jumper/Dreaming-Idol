using UnityEngine;

public class Gatherer : Unit
{
    public override string GetClassName() { return "Gatherer"; }
    public override Color GetClassColor() { return new Color(0.75f, 1, 0.5f); }
    public override string GetTopName() { return "Perception"; }
    public override string GetBotName() { return "Foresight"; }
    public override string GetTopAlias() { return "PER"; }
    public override string GetBotAlias() { return "FOR"; }
}
