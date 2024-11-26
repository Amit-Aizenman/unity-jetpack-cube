using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int _movementFlag = 1;
    [SerializeField] bool _horizontalMovementFlag = true; // True if vertical, false if horizontal
    [SerializeField] private float speed = 2;
    [SerializeField] private int damage = 1;
    private Rigidbody _rigidbody;
    private Vector3 _initialPosition;
    private bool _resetFlag = false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_resetFlag)
        {
            transform.position = _initialPosition;
            _resetFlag = false;
        }
        else
        {
            if (_horizontalMovementFlag)
            {
                this.transform.position += Vector3.right * (Time.deltaTime * _movementFlag * speed);
            }
            else
            {
                this.transform.position += Vector3.up * (Time.deltaTime * _movementFlag * speed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _movementFlag *= -1;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            MyEvents.OnEnemyHit?.Invoke(damage);
        }
    }
    
    private void OnEnable()
    {
        MyEvents.EnemyReset += ResetPosition;
    }

    private void OnDisable()
    {
        MyEvents.OnPointCollected -= ResetPosition;
    }

    public void ResetPosition(int num)
    {
        transform.position = _initialPosition;
    }
}
