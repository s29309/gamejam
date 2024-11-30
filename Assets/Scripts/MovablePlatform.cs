using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    public Transform posA, posB;
    private Rigidbody2D _rigidbody2D;
    private bool _horizontal;
    private bool _vertical;
    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Math.Round(posA.position.y) == Math.Round(posB.position.y))
        {
            _horizontal = true;
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            _vertical = true;
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        if (_horizontal) pos.x = Mathf.Clamp(pos.x, posA.position.x, posB.position.x);
        if (_vertical) pos.y = Mathf.Clamp(pos.y, posA.position.y, posB.position.y);
        transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
