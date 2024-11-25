using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int _movementFlag = 1;
    [SerializeField] bool _horizontalMovementFlag = true; // True if vertical, false if horizontal
    [SerializeField] private float speed = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
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
        Console.WriteLine("hi");
        if (_movementFlag == 1)
        {
            _movementFlag = 0;
        }
        else
        {
            _movementFlag = 1;
        }
    }
}
