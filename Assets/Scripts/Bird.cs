using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer renderer;
    public CircleCollider2D collider;

    public float flapPower = 5;
    public bool birdIsAlive = true;

    public Sprite wingDown;
    public Sprite wingUp;
    public bool wingIsUp = false;

    private GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        rigidbody2D = FindObjectOfType<Rigidbody2D>();

        manager.loadHighscore();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            rigidbody2D.velocity = Vector2.up * flapPower;
            
            if (wingIsUp)
            {
                renderer.sprite = wingDown;
                wingIsUp = false;
            }
            else
            {
                renderer.sprite = wingUp;
                wingIsUp = true;
            }
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
        collider.enabled = false;
        manager.gameOver();
        birdIsAlive = false;
    }
}
