using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{

	private void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "End")
		{
			Debug.Log ("Send Message");
			col.gameObject.SendMessage ("Activate");
		}
	}
}