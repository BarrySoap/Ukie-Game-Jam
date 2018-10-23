using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//Animation
	[SerializeField]
	private Animator anim;

	Rigidbody2D playerBody;
	BoxCollider2D playerCollider;

	[SerializeField]
	private float jumpForce = 10;
	[SerializeField]
	public float runSpeed = 20;

	public float dashMultiplier = 2;
	public float dashDuration = 1;
	public float dashCooldown = 0.5f;
	public float holdJumpCooldown = 0.2f;
	public float holdMultiplier = 4;
	public bool moving = true;

	private bool isGrounded;

	private float dashTimer = 0;
	private float holdJumpTimer = 0;
	private float defaultSize;
	private Vector2 defaultOrigin;

	// Use this for initialization
	void Start()
	{
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		playerCollider = gameObject.GetComponent<BoxCollider2D>();
		defaultSize = playerCollider.size.y;
		defaultOrigin = playerCollider.offset;
		//Debug.Log(defaultSize + ", " + defaultOrigin);

	}

	// Update is called once per frame
	void Update()
	{
		//constant movement
		MoveRight();

		//jump logic
		JumpInputs();
		holdJumpTimer -= Time.deltaTime;

		//dash logic
		DashInputs();
		dashTimer -= Time.deltaTime;

		//Duck logic
		DuckInputs();

	}

	//set player to grounded to allow them to jump when colliding with floor
	private void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log("Collided with " + col.gameObject.name);
		if (col.gameObject.tag == "Platform")
		{
			anim.SetBool("jump", false);
			isGrounded = true;
		}
	}

	//when character is jumping it will exit collision and no longer be grounded
	private void OnCollisionExit2D(Collision2D col)
	{
		//Debug.Log("Jumping");

		if (col.gameObject.tag == "Platform")
		{
			isGrounded = false;
		}

		holdJumpTimer = holdJumpCooldown;
	}

	//take jump inputs
	void JumpInputs()
	{
		if (Input.GetAxis("Jump") > 0)
		{
			anim.SetBool("jump", true);
			if (isGrounded)
			{
				Jump();
			}
			else
				HoldJump();
		}
	}

	//physical jump
	void Jump()
	{
		playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
	}

	void HoldJump()
	{
		if (holdJumpTimer > 0)
			playerBody.velocity += new Vector2(playerBody.velocity.x, holdMultiplier * jumpForce) * Time.deltaTime;
	}

	void DashInputs()
	{
		//if dash cooled down allow another dash
		if (dashTimer <= 0)
		{
			if (Input.GetAxis("Fire1") > 0)
			{
				StartCoroutine(Dash());
				dashTimer = dashCooldown;
			}
		}
	}

	//coroutine to do dash actions over a period of time
	IEnumerator Dash()
	{
		anim.SetBool("dash", true);
		runSpeed = runSpeed * dashMultiplier;
		yield return new WaitForSeconds(dashDuration);
		anim.SetBool("dash", false);
		runSpeed = runSpeed / dashMultiplier;
	}

	void DuckInputs()
	{
		if (Input.GetAxis("Vertical") < 0)
		{
			anim.SetBool("duck", true);
			Duck(true);
		}
		else
		{
			anim.SetBool("duck", false);
			Duck(false);
		}
	}

	void Duck(bool ducking)
	{
		if (ducking)
		{
			//shrink and lower hitbox for duck action
			playerCollider.size = new Vector2(playerCollider.size.x, defaultSize / 2);
			playerCollider.offset = new Vector2(0, defaultOrigin.y - (defaultSize / 5));
		}
		else
		{
			//restet hitbox to default values
			playerCollider.size = playerCollider.size = new Vector2(playerCollider.size.x, defaultSize);
			playerCollider.offset = defaultOrigin;
		}

	}

	//constantly moving
	void MoveRight()
	{
		if (moving == true)
			playerBody.velocity = new Vector2(runSpeed, playerBody.velocity.y);
		else
			playerBody.velocity = new Vector2(0, playerBody.velocity.y);
	}

    public void KillFish()
    {
        moving = false;
        anim.SetBool("dead", true);
    }
}