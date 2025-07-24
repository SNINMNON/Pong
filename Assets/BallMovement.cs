using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetInitialSpeed();
    }

    private void SetInitialSpeed()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        rb.velocity = new Vector2(x, y).normalized * Random.Range(minSpeed, maxSpeed);
    }

    public void Restart()
    {
        transform.position = Vector3.zero;
        SetInitialSpeed();
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
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
        
        rb.velocity = new Vector2(x, y).normalized * Random.Range(minSpeed, maxSpeed);
    }
}
