using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown = 1f;
    [SerializeField] private RaceType _raceType;
    [SerializeField] private float _enemySpeed;

    private OrcRaceFactory _orcFactory;
    private ElfRaceFactory _elfFactory;

    private RaceEnemyFactory _enemyFactory;

    private float _spawnOffset = 1f;
    private Vector3 _spawnPoint;

    private Coroutine _spawn;

    public void Initialize(OrcRaceFactory orcRaceFactory, ElfRaceFactory elfRaceFactory)
    {
        _elfFactory = elfRaceFactory;
        _orcFactory = orcRaceFactory;

        _spawnPoint = new Vector3(transform.position.x, transform.position.y + _spawnOffset, transform.position.z);

        ChooseFabric(_raceType);
    }

    public void StartWork()
    {
        StopWork();
        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
        {
            StopCoroutine(_spawn);
        }
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            ClassType selectedClassType = (ClassType)Random.Range(0, Enum.GetValues(typeof(ClassType)).Length);
            Enemy enemy = _enemyFactory.Get(selectedClassType);

            enemy.Initialize(_enemySpeed);
            enemy.transform.position = _spawnPoint;

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private void ChooseFabric(RaceType raceType)
    {
        switch (raceType)
        {
            case RaceType.Orc:
                _enemyFactory = _orcFactory;
                break;

            case RaceType.Elf:
                _enemyFactory = _elfFactory;
                break;

            default: throw new ArgumentException(nameof(raceType));
        }
    }

    public void SwitchRaceType()
    {
        switch (_raceType)
        {
            case RaceType.Elf:
                _raceType = RaceType.Orc;
                break;

            case RaceType.Orc:
                _raceType = RaceType.Elf;
                break;
        }

        ChooseFabric(_raceType);
        StartWork();
    }
}
