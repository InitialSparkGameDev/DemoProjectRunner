using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform Spawn;

    private Transform[] _spawnPoints;

    private float _secondsBetweenSpawn;
    private float _elapsedTime;

    private void Start()
    {
        _spawnPoints = new Transform[Spawn.childCount];

        for (int i = 0; i < Spawn.childCount; i++)
        {
            _spawnPoints[i] = Spawn.GetChild(i);
        }

        _secondsBetweenSpawn = 1;

        Initialize(_enemyTemplates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }
}
