using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float flapPower = 5;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            rigidbody2D.velocity = Vector2.up * flapPower;
        }
    }
}
