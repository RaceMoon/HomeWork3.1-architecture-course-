using UnityEngine;

public class PaladinElf : Paladin
{
    public override void Initialize(float speed)
    {
        base.Initialize(speed);
    }

    protected override void Attack()
    {
        Debug.Log("Ёльф стрел€ет из лука");
    }
}
