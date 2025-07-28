using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPaddle : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 paddleSize;
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var sr = GetComponent<SpriteRenderer>();
        paddleSize = sr.sprite.bounds.size;
        ball = GameObject.FindWithTag("ball");

        GameManager.Instance.restartEvent.AddListener(ResetPosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball == null) return;
        int direction;
        if (ball.transform.position.y > rb.position.y + paddleSize.y / 2) direction = 1;
        else if (ball.transform.position.y < rb.position.y - paddleSize.y / 2) direction = -1;
        else direction = 0;

        Vector2 dest = new(rb.position.x, rb.position.y + speed * Time.deltaTime * direction);
        rb.MovePosition(dest);
    }

    void ResetPosition()
    {
        transform.position = new Vector3(-8, 0, 0);
    }
}
