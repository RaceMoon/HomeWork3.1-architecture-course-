using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] List<EnemySpawner> _spawners;

    [SerializeField] PaladinElf _paladinElfPrefab;
    [SerializeField] PaladinOrc _paladinOrcPrefab;
    [SerializeField] WizardOrc _wizardOrcPrefab;
    [SerializeField] WizardElf _wizardElfPrefab;
   

    private void Awake()
    {
        OrcRaceFactory orcRaceFactory = new OrcRaceFactory(_paladinOrcPrefab, _wizardOrcPrefab);
        ElfRaceFactory elfRaceFactory = new ElfRaceFactory(_paladinElfPrefab, _wizardElfPrefab);

        foreach (var spawner in _spawners)
        {
            spawner.Initialize(orcRaceFactory, elfRaceFactory);
            spawner.StartWork();
        }
    }
}
