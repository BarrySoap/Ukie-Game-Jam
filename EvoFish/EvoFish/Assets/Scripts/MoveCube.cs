using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {

    Vector3 _movement = new Vector3(1.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(_movement * Time.deltaTime);

        // Debugging purposes. Had to check multiple collisions.
        if (Input.GetKeyDown("space"))
        {
            _movement *= -1;
        }
    }
}
