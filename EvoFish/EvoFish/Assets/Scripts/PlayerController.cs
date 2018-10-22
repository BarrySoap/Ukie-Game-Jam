using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	Rigidbody2D playerBody;
	[SerializeField]
	private float jumpForce = 10;
	[SerializeField]
	private float runSpeed = 20;

	public float dashMultiplier = 2;
	public float dashDuration = 1;
	public float dashCooldown = 0.5f;

	private bool isGrounded;
	private float dashTimer;

	// Use this for initialization
	void Start ()
	{
		playerBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		//constant movement
		MoveRight ();

		//jump logic
		JumpInputs ();

		//dash logic
		DashInputs ();
		dashTimer -= Time.deltaTime;
	}

	//set player to grounded to allow them to jump when colliding with floor
	private void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Collided with " + col.gameObject.name);
		if (col.gameObject.name == "Ground")
		{
			isGrounded = true;
		}
	}

	//when character is jumping it will exit collision and no longer be grounded
	private void OnCollisionExit2D (Collision2D col)
	{
		Debug.Log ("Jumping");

		if (col.gameObject.name == "Ground")
		{
			isGrounded = false;
		}
	}

	//take jump inputs
	void JumpInputs ()
	{
		if (Input.GetAxis ("Jump") != 0)
		{
			if (isGrounded)
			{
				Jump ();
			}
		}
	}

	//physical jump
	void Jump ()
	{
		playerBody.velocity = new Vector2 (playerBody.velocity.x, jumpForce);
	}

	void DashInputs ()
	{
		if (dashTimer <= 0)
		{
			if (Input.GetAxis ("Fire1") != 0)
			{
				StartCoroutine (Dash ());
				dashTimer = dashCooldown;
			}
		}

	}
	IEnumerator Dash ()
	{
		runSpeed = runSpeed * dashMultiplier;
		yield return new WaitForSeconds (dashDuration);
		runSpeed = runSpeed / dashMultiplier;
	}

	void MoveRight ()
	{
		playerBody.velocity = new Vector2 (runSpeed, playerBody.velocity.y);
	}
}