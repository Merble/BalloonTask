using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPoint : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
