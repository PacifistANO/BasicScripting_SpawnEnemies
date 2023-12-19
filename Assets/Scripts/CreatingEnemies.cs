using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System;

public class CreatingEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private int _countEnemies;
    private float _maxCountEnemies = 10;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var spawnTime = new WaitForSeconds(2f);

        while (_countEnemies < _maxCountEnemies)
        {
            Transform spawn = transform.GetChild(UnityEngine.Random.Range(0, transform.childCount));
            Enemy newEnemy = Instantiate(_enemy, new Vector2(spawn.transform.localPosition.x, spawn.localPosition.y), Quaternion.identity);
            newEnemy.GetComponent<SpriteRenderer>().flipX = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
            _countEnemies++;

            if (_countEnemies == _maxCountEnemies)
            {
                StopCoroutine(_spawnCoroutine);
            }

            yield return spawnTime;
        }
    }
}
