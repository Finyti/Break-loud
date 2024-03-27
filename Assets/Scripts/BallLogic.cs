using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    Rigidbody2D rb;

    public float ballReflectDiviation;
    public float maxSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CheckSpeed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var colRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (colRb != null)
        {
            rb.velocity += colRb.velocity * ballReflectDiviation;
        }
    }
    
    public void CheckSpeed()
    {
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, 0);
        }
        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(0, maxSpeed);
        }
    }
}
