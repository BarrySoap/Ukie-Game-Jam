using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollEnemy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Platform")
        {
            Vector3 pos = gameObject.transform.position;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
