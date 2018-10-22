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
	public float holdJumpCooldown = 0.2f;
	public float holdMultiplier = 4;

	private bool isGrounded;
	private float dashTimer = 0;
	private float holdJumpTimer = 0;

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
		holdJumpTimer -= Time.deltaTime;

		//dash logic
		DashInputs ();
		dashTimer -= Time.deltaTime;
	}

	//set player to grounded to allow them to jump when colliding with floor
	private void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Collided with " + col.gameObject.name);
		if (col.gameObject.tag == "Platform")
		{
			isGrounded = true;
		}
	}

	//when character is jumping it will exit collision and no longer be grounded
	private void OnCollisionExit2D (Collision2D col)
	{
		Debug.Log ("Jumping");

		if (col.gameObject.tag == "Platform")
		{
			isGrounded = false;
		}

		holdJumpTimer = holdJumpCooldown;
	}

	//take jump inputs
	void JumpInputs ()
	{
		if (Input.GetAxis ("Jump") > 0)
		{
			if (isGrounded)
				Jump ();
			else
				HoldJump ();
		}
	}

	//physical jump
	void Jump ()
	{
		playerBody.velocity = new Vector2 (playerBody.velocity.x, jumpForce);
	}

	void HoldJump ()
	{
		if (holdJumpTimer > 0)
			playerBody.velocity += new Vector2 (playerBody.velocity.x, holdMultiplier * jumpForce) * Time.deltaTime;
	}

	void DashInputs ()
	{
		//if dash cooled down allow another dash
		if (dashTimer <= 0)
		{
			if (Input.GetAxis ("Fire1") != 0)
			{
				StartCoroutine (Dash ());
				dashTimer = dashCooldown;
			}
		}
	}

	//coroutine to do dash actions over a period of time
	IEnumerator Dash ()
	{
		runSpeed = runSpeed * dashMultiplier;
		yield return new WaitForSeconds (dashDuration);
		runSpeed = runSpeed / dashMultiplier;
	}

	//constantly moving
	void MoveRight ()
	{
		playerBody.velocity = new Vector2 (runSpeed, playerBody.velocity.y);
	}
}