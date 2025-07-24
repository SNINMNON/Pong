using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;

    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int direction;
        if (Input.GetKey(upKey) && Input.GetKey(downKey)) direction = 0;
        else if (Input.GetKey(upKey)) direction = 1;
        else if (Input.GetKey(downKey)) direction = -1;
        else direction = 0;

        Vector2 dest = new(rb.position.x, rb.position.y + speed * Time.deltaTime * direction);
        rb.MovePosition(dest);
    }

}
