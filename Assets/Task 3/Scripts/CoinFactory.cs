using System.Collections.Generic;
using UnityEngine;

public class CoinFactory
{
    private const int CountOfTryGetPoints = 1000;

    private Coin _coinPrefab;
    private float _spawnDistance;
    private Vector3 _centerOfSpawnPoint;
    private float _minDistanceBetweenCoin;

    private Queue<Vector3> _spawnPoints;

    public CoinFactory(Coin coinPrefab, float spawnRadius, Vector3 spawnPoint, float minDistanceBetweenPoint)
    {
        _spawnPoints = new Queue<Vector3>();
        _coinPrefab = coinPrefab;
        _minDistanceBetweenCoin = minDistanceBetweenPoint;
        _spawnDistance = spawnRadius;
        _centerOfSpawnPoint = spawnPoint;
        SetSpawnPoints();
    }

    public void Get()
    {
        if (_spawnPoints.Count > 0)
        {
            Object.Instantiate(_coinPrefab, _spawnPoints.Dequeue(), Quaternion.identity);
        } else
        {
            Debug.Log("Точки для спавна закончились");
        }
    }

    private void SetSpawnPoints()
    {
        Vector3 newSpawnPoint;

        _spawnPoints.Enqueue(GenerateSpawnPoint());

        for (int i = 0; i < CountOfTryGetPoints; i++)
        {
            bool isSpawnPointFits = true;

            newSpawnPoint = GenerateSpawnPoint();

            foreach (Vector3 points in _spawnPoints)
            {
                if (Vector3.Distance(newSpawnPoint, points) < _minDistanceBetweenCoin)
                {
                    isSpawnPointFits = false;
                    break;
                }
            }

            if (isSpawnPointFits)
            {
                _spawnPoints.Enqueue(newSpawnPoint);
            }
        }
    }
    private Vector3 GenerateSpawnPoint()
    {
        float xPointOffcet, zPointOffcet;
        float xSpawnPoint, zSpawnPoint;

        xPointOffcet = UnityEngine.Random.Range(-_spawnDistance, _spawnDistance);
        zPointOffcet = UnityEngine.Random.Range(-_spawnDistance, _spawnDistance);

        xSpawnPoint = _centerOfSpawnPoint.x + xPointOffcet;
        zSpawnPoint = _centerOfSpawnPoint.y + zPointOffcet;

        return new Vector3(xSpawnPoint, _centerOfSpawnPoint.y, zSpawnPoint);
    }
}


