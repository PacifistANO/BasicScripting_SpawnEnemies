using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Enemy))]

public class CreatingEnemies : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private Enemy _enemy;

    private Transform[] _spawns;
    private int _currentSpawn = 0;
    private int _countEnemies;
    private float _maxCountEnemies = 6;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawns = new Transform[_spawn.childCount];

        for(int i = 0; i < _spawn.childCount; i++)
        {
            _spawns[i] = _spawn.GetChild(i);
        }

        _spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var spawnTime = new WaitForSeconds(2f);

        while (_countEnemies < _maxCountEnemies)
        {
            if (_currentSpawn < _spawn.childCount)
            {
                Instantiate(_enemy, new Vector2(_spawns[_currentSpawn].localPosition.x, _spawns[_currentSpawn].localPosition.y), Quaternion.identity);
                _currentSpawn++;
                _countEnemies++;

                if (_currentSpawn == _spawn.childCount)
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
