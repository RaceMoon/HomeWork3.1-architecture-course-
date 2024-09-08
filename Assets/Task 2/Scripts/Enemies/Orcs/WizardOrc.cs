using UnityEngine;

public class WizardOrc : Wizard
{
    public override void Initialize(float speed)
    {
        base.Initialize(speed);
    }

    protected override void Cast()
    {
        Debug.Log("Орк кастует каменную кожу");
    }
}
