using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    Rigidbody2D rb;

    public float ballReflectDiviation;
    public float maxSpeed;

    public BallShoot bs;

    public AudioClip ballHit;
    public AudioClip ballDie;
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
        AudioManager.Play(ballHit, 1, 1);
        var colRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (colRb != null)
        {
            rb.velocity += colRb.velocity * ballReflectDiviation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.Play(ballDie, 1, 1);
        if (collision.gameObject.CompareTag("LoosePoint"))
        {
            bs.BallLoose();
            Destroy(gameObject);
        }
    }

    public void CheckSpeed()
    {
        if (!bs.gameManager.GameGoing)
        {
            rb.velocity = Vector2.zero;
            return;
        }
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
