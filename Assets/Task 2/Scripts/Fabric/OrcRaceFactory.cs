using System;

public class OrcRaceFactory : RaceEnemyFactory
{
    private PaladinOrc _paladinOrcPrefab;
    private WizardOrc _wizardOrcPrefab;

    public OrcRaceFactory(PaladinOrc paladinOrcPrefab, WizardOrc wizardOrcPrefab)
    {
        _paladinOrcPrefab = paladinOrcPrefab;
        _wizardOrcPrefab = wizardOrcPrefab;
    }
    public override Enemy Get(ClassType classType)
    {
        switch (classType)
        {
            case ClassType.Paladin:
                return UnityEngine.Object.Instantiate(_paladinOrcPrefab);

            case ClassType.Wizard: 
                return UnityEngine.Object.Instantiate(_wizardOrcPrefab); ;

            default: throw new ArgumentException(nameof(classType));
        }
    }
}
