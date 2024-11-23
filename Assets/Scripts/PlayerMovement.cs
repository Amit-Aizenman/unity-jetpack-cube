using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _horizontalMovement;
    private float _verticalMovement;
    [SerializeField] private float force = 1000;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     _rigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.right * _horizontalMovement * Time.fixedDeltaTime * force);
        _rigidbody.AddForce(Vector3.up * _verticalMovement * Time.fixedDeltaTime * force);
    }
}
