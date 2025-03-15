using System;
using System.Drawing;
using NUnit.Framework.Constraints;
using UnityEngine;
using Object = System.Object;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _horizontalMovement;
    private bool _verticalMovement;
    [SerializeField] private float force = 1000;
    private int _maxSpeed = 100;
    private int _maxFlySpeed = 100;
    private Vector3 _initialPosition;
    public static bool _playerResetFlag = false;
    
    void Start()
    {
     _rigidbody = GetComponent<Rigidbody>();
     _initialPosition = transform.position;
    }

    void Update()
    {
        
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetKey(KeyCode.Space);
        if (_playerResetFlag)
        {
            transform.position = _initialPosition;
            _playerResetFlag = false;
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody.linearVelocity.x < _maxSpeed) {
            _rigidbody.AddForce(Vector3.right * (_horizontalMovement * Time.fixedDeltaTime * force));
        }

        if (_rigidbody.linearVelocity.y < _maxFlySpeed && _verticalMovement){
            _rigidbody.AddForce(Vector3.up * (Time.fixedDeltaTime * force));
        }
    }
}
