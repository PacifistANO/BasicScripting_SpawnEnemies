using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateEnemies : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private GameObject _enemy;

    private Transform[] _spawns;
    private int _spawnTime = 2;
    private int _currentSpawn = 0;
    private float _spawnInterval;

    void Awake()
    {
        _spawns = new Transform[_spawn.childCount];

        for(int i = 0; i < _spawn.childCount; i++)
        {
            _spawns[i] = _spawn.GetChild(i);
        }

        Instantiate(_enemy, new Vector2(_spawns[_currentSpawn].localPosition.x, _spawns[_currentSpawn].localPosition.y), Quaternion.identity);
        _currentSpawn++;
    }

    void Update()
    {
        _spawnInterval += Time.deltaTime;

        if(_spawnInterval >= _spawnTime && _currentSpawn < _spawn.childCount)
        {
            Instantiate(_enemy, new Vector2(_spawns[_currentSpawn].localPosition.x, _spawns[_currentSpawn].localPosition.y), Quaternion.identity);
            _currentSpawn++;
            _spawnInterval = 0;

            if (_currentSpawn == _spawn.childCount)
            {
                _currentSpawn = 0;
            }
        }
    }
}
