using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _minDistanceBetweenPoints;
    [SerializeField] private Coin _coinPrefab;

    private CoinFactory _coinFactory;

    private Coroutine _coroutine;

    public void Awake()
    {
        _coinFactory = new CoinFactory(_coinPrefab, _spawnDistance, transform.position, _minDistanceBetweenPoints);
    }

    public void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public void Start()
    {
        Stop();
        _coroutine = StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            _coinFactory.Get();

            yield return new WaitForSeconds(_spawnTime);
        }
    }

}
