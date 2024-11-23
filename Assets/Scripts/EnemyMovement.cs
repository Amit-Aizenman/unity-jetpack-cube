using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool _movementFlag = false;
    [SerializeField] private bool _horizontalMovementFlag = true; // True if vertical, false if horizontal
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_movementFlag)
        {
            _movementFlag = false;
        }
        else
        {
            _movementFlag = true;
        }
    }
}
