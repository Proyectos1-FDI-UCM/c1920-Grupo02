using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Rigidbody2D rb;
    float initialPosition;
    private SpriteRenderer spriteRenderer;
    public int direction;
    public float patrolSpeed;
    private void Awake()
    {
        initialPosition = transform.position.x;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * patrolSpeed, 0);
    }
    private void OnEnable()
    {
        if (initialPosition < transform.position.x)
        {
            direction = -1;
            spriteRenderer.flipX = true;
        }
        else
        {
            direction = 1;
            spriteRenderer.flipX = false;
        }
    }
}