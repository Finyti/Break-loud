using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector2 moveArea;
    public float playerSpeed;
    public GameManager gameManager;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    void Update()
    {
        if (!gameManager.GameGoing)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -moveArea.x)
        {
            PlayerVelocity(-1f);
        }
        else if (Input.GetKey(KeyCode.D) && transform.position.x < moveArea.x)
        {
            PlayerVelocity(1f);
        }
        else
        {
            PlayerVelocity(0f);
        }
    }

    public void PlayerVelocity(float direction)
    {
        rb.velocity = new Vector2(direction * playerSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f)
        .ChangeStartValue(new Vector3(1f, 1f, 1f))
        .SetEase(Ease.InOutBounce)
        .SetLoops(2, LoopType.Yoyo);
    }


}
