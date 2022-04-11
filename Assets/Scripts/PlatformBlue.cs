using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBlue : MonoBehaviour {

    public float jumpForce = 10f;
    public float minY = .2f;
    public float maxY = 1.5f;
    private Vector3 posCreate;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }

    private void Start()
    {
        posCreate = transform.position;
    }

    void Update ()
    {
        Debug.Log(posCreate);
    }

}