using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHandle : MonoBehaviour
{
    [SerializeField] private Transform handle;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(handle.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
