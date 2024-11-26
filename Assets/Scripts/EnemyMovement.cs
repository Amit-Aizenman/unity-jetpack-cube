using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int _movementFlag = 1;
    [SerializeField] bool _horizontalMovementFlag = true; // True if vertical, false if horizontal
    [SerializeField] private float speed = 2;
    private Rigidbody _rigidbody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_horizontalMovementFlag){
            this.transform.position += Vector3.right * (Time.deltaTime * _movementFlag *speed);
        }
        else
        {
            this.transform.position += Vector3.up * (Time.deltaTime * _movementFlag * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _movementFlag *= -1;
        }
    }
}
