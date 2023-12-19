using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System;

public class CreatingEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private int _countEnemies;
    private float _maxCountEnemies = 10;
    private Coroutine _spawnCoroutine;
    private int[] _direction = { -1, 1 };

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var spawnTime = new WaitForSeconds(2f);

        while (_countEnemies < _maxCountEnemies)
        {
            Transform spawnPoint = transform.GetChild(UnityEngine.Random.Range(0, transform.childCount));
            Enemy newEnemy = Instantiate(_enemyPrefab, new Vector2(spawnPoint.localPosition.x, spawnPoint.localPosition.y), Quaternion.identity);
            newEnemy.GetComponent<EnemyMover>().SetDirection(_direction[UnityEngine.Random.Range(0,_direction.Length)]);
            _countEnemies++;

            if (_countEnemies == _maxCountEnemies)
            {
                StopCoroutine(_spawnCoroutine);
            }

            yield return spawnTime;
        }
    }
}
