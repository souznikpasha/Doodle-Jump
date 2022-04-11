using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	[SerializeField] private Transform player;
	public float movementSpeed = 10f;

	Rigidbody2D rb;

	float movement = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		
		Resolution[] resolutions = Screen.resolutions;
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal") * movementSpeed;
			
		// if (player.position.x > 4.35)
		// {
		// 	
		// 	Debug.Log("я возле границы справа");
		// }
		// if (player.position.x < -4.35)
		// {
		// 	Debug.Log("я возле границы слева");
		// }
	}

	void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}

}
