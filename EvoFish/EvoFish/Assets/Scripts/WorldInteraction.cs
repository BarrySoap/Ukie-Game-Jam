using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
	BoxCollider2D playerCollider;

	private void Start ()
	{
		playerCollider = gameObject.GetComponent<BoxCollider2D> ();
	}

	private void OnTriggerEnter2D (Collider2D col)
	{
		//end of level interaction
		if (col.gameObject.tag == "End")
		{
			Debug.Log ("Send Message");
			//col.gameObject.SendMessage("Activate");
			EndZone e = col.gameObject.GetComponent<EndZone> ();
			e.Activate ();
		}

		//hit by enemy/obstacle
		if (col.gameObject.tag == "Obstacle")
		{
			Debug.Log ("Obstacle encountered!");

			EndZone e = col.gameObject.GetComponent<EndZone> ();
			e.Activate ();

			//simulate death animation
			playerCollider.enabled = false;
			gameObject.GetComponent<PlayerController> ().moving = false;
		}
	}
}