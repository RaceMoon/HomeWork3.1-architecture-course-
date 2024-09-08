using System;

public class ElfRaceFactory : RaceEnemyFactory
{
    private PaladinElf _paladinElfPrefab;
    private WizardElf _wizardElfPrefab;

    public ElfRaceFactory(PaladinElf paladinElfPrefab, WizardElf wizardElfPrefab)
    {
        _paladinElfPrefab = paladinElfPrefab;
        _wizardElfPrefab = wizardElfPrefab;
    }
    public override Enemy Get(ClassType classType)
    {
        switch (classType)
        {
            case ClassType.Paladin:
                return UnityEngine.Object.Instantiate(_paladinElfPrefab);

            case ClassType.Wizard:
                return  UnityEngine.Object.Instantiate(_wizardElfPrefab);

            default: throw new ArgumentException(nameof(classType));
        }
    }
}
