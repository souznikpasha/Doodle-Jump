using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformBlue : MonoBehaviour {

    [SerializeField] private float moveSpeed=0.05f;
    private float jumpForce = 10f;
    private float minY = .2f;
    private float maxY = 1.5f;
    private float levelWidth = 8.80f;
    private Vector3 _posCreate;
    private int sideMove;
    private int verticalOrHorizontal;
    private float screenBorder=4.5f;
 

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
        sideMove = Random.Range(0, 2);
        verticalOrHorizontal = Random.Range(0, 2);//0-horizont 1- vertical
        _posCreate = transform.position;
    }

    void Update ()
    {
        Move(sideMove,verticalOrHorizontal);
        if (transform.position.x > screenBorder || transform.position.y > screenBorder) 
            sideMove = 0;
        if (transform.position.x <-screenBorder || transform.position.y <-screenBorder) 
            sideMove = 1;

    }

    void Move(int sideMove, int gorVertMove)
    {
       
        if (gorVertMove == 0)
        {

            if (sideMove == 1) //right
            {
                transform.position = new Vector3((transform.position.x + moveSpeed), transform.position.y,
                    transform.position.z);
            }

            if (sideMove == 0) //left
            {
                transform.position = new Vector3((transform.position.x - moveSpeed), transform.position.y,
                    transform.position.z);
            }
        }
        if(gorVertMove == 1)
        {
            if (sideMove == 1) //up
            {
                transform.position = new Vector3(transform.position.x, transform.position.y+moveSpeed,
                    transform.position.z);
            }

            if (sideMove == 0) //down
            {
                transform.position = new Vector3(transform.position.x, transform.position.y-moveSpeed,
                    transform.position.z);
            }
        }

    }

}