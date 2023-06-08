using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Enemy))]

public class CreatingEnemies : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _enemy;

    private Transform[] _spawnPoints;
    private int _currentSpawn = 0;
    private int _countEnemies;
    private float _maxCountEnemies = 6;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnPoint.childCount];

        for(int i = 0; i < _spawnPoint.childCount; i++)
        {
            _spawnPoints[i] = _spawnPoint.GetChild(i);
        }

        _spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var spawnTime = new WaitForSeconds(2f);

        while (_countEnemies < _maxCountEnemies)
        {
            if (_currentSpawn < _spawnPoint.childCount)
            {
                Instantiate(_enemy, new Vector2(_spawnPoints[_currentSpawn].localPosition.x, _spawnPoints[_currentSpawn].localPosition.y), Quaternion.identity);
                _currentSpawn++;
                _countEnemies++;

                if (_currentSpawn == _spawnPoint.childCount)
                {
                    _currentSpawn = 0;
                }

                if (_countEnemies == _maxCountEnemies)
                {
                    StopCoroutine(_spawnCoroutine);
                }

                yield return spawnTime;
            }
        }
    }
}
