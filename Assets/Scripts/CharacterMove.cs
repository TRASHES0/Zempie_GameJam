using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] float speed = 4f, jumpForce = 500f;
    float moveX;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();

        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * horizontal, ForceMode2D.Impulse);
    }

    void Movement()
    {
        moveX = Input.GetAxis("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * jumpForce);

        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }
}
