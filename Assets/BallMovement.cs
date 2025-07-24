using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float speedVariation;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    private float speed;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Restart()
    {
        transform.position = Vector3.zero;
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        speed = Random.Range(minSpeed, minSpeed + speedVariation);
        rb.velocity = new Vector2(x, y).normalized * speed;
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
        if (rb.velocity == Vector2.zero)
        {
            Restart();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        float x, y;

        if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
        {
            // Hit vertical surface - preserve Y direction, reverse X
            x = -Mathf.Sign(lastVelocity.x);
            y = Mathf.Sign(lastVelocity.y) * Random.Range(0.3f, 0.75f);
        }
        else
        {
            // Hit horizontal surface - preserve X direction, reverse Y
            x = Mathf.Sign(lastVelocity.x) * Random.Range(0.3f, 0.75f);
            y = -Mathf.Sign(lastVelocity.y);
        }

        
        if (speed == maxSpeed)
        {
            rb.velocity = new Vector2(x, y).normalized * speed;
        }
        else
        {   // increase speed every hit
            float fasterSpeed = Mathf.Min(Random.Range(speed, speed + speedVariation), maxSpeed);
            rb.velocity = new Vector2(x, y).normalized * fasterSpeed;
            speed = fasterSpeed;
        }

        Debug.Log($"Ball speed: {speed}");
        
    }
}
