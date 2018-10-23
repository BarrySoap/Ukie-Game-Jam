using System.Collections;
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

		if (SceneToLoad == null || SceneToLoad == "")
			SceneToLoad = SceneManager.GetActiveScene ().name.ToString ();
	}

	//get activated by collision
	public void Activate ()
	{
		Debug.Log ("Activate");
		activated = true;
	}

	public void Level1 ()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void Level2 ()
	{
		SceneManager.LoadScene ("Level2");
	}

	public void Level3 ()
	{
		SceneManager.LoadScene ("Level3");
	}

	public void Level4 ()
	{
		SceneManager.LoadScene ("Level4");
	}

	public void InstantSwitch ()
	{
		SceneManager.LoadScene (SceneToLoad);
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
			// if (SceneToLoad == null || SceneToLoad == "")
			// 	SceneToLoad = SceneManager.GetActiveScene().name.ToString();

			SceneManager.LoadScene (SceneToLoad);
		}
	}
}