using System;
using System.Drawing;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _horizontalMovement;
    private bool _verticalMovement;
    [SerializeField] private float force = 1000;
    private int _initialHealth = 100;
    private int _maxSpeed = 100;
    private int _maxFlySpeed = 100;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     _rigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetKey(KeyCode.Space);
        
    }

    private void FixedUpdate()
    {
        if (_rigidbody.linearVelocity.x < _maxSpeed)
        {
            _rigidbody.AddForce(Vector3.right * (_horizontalMovement * Time.fixedDeltaTime * force));
        }

        if (_rigidbody.linearVelocity.y < _maxFlySpeed && _verticalMovement)
        {
            _rigidbody.AddForce(Vector3.up * (Time.fixedDeltaTime * force));
        }
    }
    
    private void EnemyHit(int damage)
    {
        _initialHealth -= damage;
        print ("Character got hit! Health is now " + _initialHealth);
    }
    
    private void OnEnable()
    {
        MyEvents.OnEnemyHit += EnemyHit;
    }

    private void OnDisable()
    {
        MyEvents.OnPointCollected -= EnemyHit;
    }
    
}
