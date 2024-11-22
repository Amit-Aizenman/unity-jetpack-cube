using UnityEngine;
using System;
public class PlayerPhysicalMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    private float _forwardMovement;
    private float _sideMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _forwardMovement = Input.GetAxis("Vertical");
        _sideMovement = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.up * _forwardMovement * Time.fixedDeltaTime * speed);
        _rigidbody.AddForce(Vector3.right * _sideMovement * Time.fixedDeltaTime * speed);
    }
}
