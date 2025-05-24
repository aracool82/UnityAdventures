using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ship : MonoBehaviour
{
    [SerializeField] private Wind _wind;
    [SerializeField] private float _speed;
    
    private Rigidbody _rigidbody;
    private Vector3 _force;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _force = _wind.Direction * _speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_force);
    }
}
