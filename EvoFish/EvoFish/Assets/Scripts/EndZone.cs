﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{

	public float Countdown;
	public string SceneToLoad;

	private float activationTimer;
	private bool activated = false;

	private BoxCollider2D endCollider;

	// Use this for initialization
	void Start ()
	{
		endCollider = gameObject.GetComponent<BoxCollider2D> ();
		activationTimer = Countdown;

		if (SceneToLoad == null)
			SceneToLoad = "Dan";

        if(SceneManager.GetActiveScene().name == "Level1")
        {
            // Change to say level 2 --------------------------------
            SceneToLoad = "Level1";
        }
	}

	//get activated by collision
	public void Activate ()
	{
		Debug.Log ("Activate");
		activated = true;
	}

	void Update ()
	{
		//decrement the timer if activated.
		if (activated)
		{
			activationTimer -= Time.deltaTime;

			//do stuff during the countdown time
			//...
		}

		//if timer runs out 
		if (activationTimer <= 0)
		{
			SceneManager.LoadScene (SceneToLoad);
		}
	}
}