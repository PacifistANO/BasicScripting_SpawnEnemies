using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _speed = 2;
    private Vector2 _direction;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(gameObject.layer,gameObject.layer);
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        _spriteRenderer.flipX = _direction.x < 0;
    }

    public void SetDirection(int direction)
    {
        _direction.x = direction;
    }
}
