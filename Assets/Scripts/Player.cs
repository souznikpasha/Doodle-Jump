using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public float movementSpeed = 10f;

	Rigidbody2D rb;

	float movement = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		
		Resolution[] resolutions = Screen.resolutions;

		// Print the resolutions
		foreach (var res in resolutions)
		{
			Debug.Log(res.width + "x" + res.height + " : " + res.refreshRate);
		}
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal") * movementSpeed;
	}

	void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}
}
