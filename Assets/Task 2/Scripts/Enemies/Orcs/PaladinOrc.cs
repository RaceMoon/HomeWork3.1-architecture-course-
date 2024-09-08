using UnityEngine;

public class PaladinOrc : Paladin
{
    public override void Initialize(float speed)
    {
        base.Initialize(speed);
    }

    protected override void Attack()
    {
        Debug.Log("Ору бьет топором");
    }
}
