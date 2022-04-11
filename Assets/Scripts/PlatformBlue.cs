using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformBlue : MonoBehaviour {

    [SerializeField] private float moveSpeed=0.04f;
    public float jumpForce = 10f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public float levelWidth = 8.80f;
    private Vector3 _posCreate;
    public int sideMove;
 

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
        sideMove = Random.Range(0, 1);
        _posCreate = transform.position;
    }

    void Update ()
    {
        Move(sideMove);
        if (transform.position.x > 4.35)
        {
            sideMove = 0;
            Debug.Log("я возле границы справа");
        }
        if (transform.position.x < -4.35)
        {
            sideMove = 1;
            Debug.Log("я возле границы слева");
        }
    }

    void Move(int sideMove)
    {
        Debug.Log(this.sideMove);

        if (sideMove == 1) //right
        {
            transform.position = new Vector3((transform.position.x+moveSpeed), transform.position.y, transform.position.z);
        } 
        if (sideMove == 0) //left
        {
            transform.position = new Vector3((transform.position.x-moveSpeed), transform.position.y, transform.position.z);
        }

    }

}