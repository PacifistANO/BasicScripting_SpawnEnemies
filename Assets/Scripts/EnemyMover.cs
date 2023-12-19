using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _speed = 2;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(gameObject.layer,gameObject.layer);
    }

    private void Update()
    {
        if (_spriteRenderer.flipX == false)
            transform.Translate(Vector2.right * Time.deltaTime * _speed, Space.Self);
        else
            transform.Translate(Vector2.left * Time.deltaTime * _speed, Space.Self);
    }
}
