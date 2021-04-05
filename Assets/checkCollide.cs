using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(name+"Colliding with "+other.collider.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
