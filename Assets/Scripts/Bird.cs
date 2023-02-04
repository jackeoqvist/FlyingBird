using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float flapPower = 5;
    public bool birdIsAlive = true;

    private GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        rigidbody2D = FindObjectOfType<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            rigidbody2D.velocity = Vector2.up * flapPower;
        }

        if (transform.position.y < -25)
        {
            die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            die(); 
        }
    }
    void die()
    {
        manager.gameOver();
        birdIsAlive = false;
    }
}
