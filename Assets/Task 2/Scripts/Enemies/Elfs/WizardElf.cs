using UnityEngine;

public class WizardElf : Wizard
{
    public override void Initialize(float speed)
    {
        base.Initialize(speed);
    }

    protected override void Cast()
    {
        Debug.Log("Ёльф кастует лечение по области");
    }
}
