using UnityEngine;

public class Explorer : Unit
{
    public override string GetClassName() { return "Explorer"; }
    public override Color GetClassColor() { return new Color(1, 1, 0.5f); }
    public override string GetTopName() { return "Bravery"; }
    public override string GetBotName() { return "Determination"; }
    public override string GetTopAlias() { return "BRA"; }
    public override string GetBotAlias() { return "DET"; }
}
