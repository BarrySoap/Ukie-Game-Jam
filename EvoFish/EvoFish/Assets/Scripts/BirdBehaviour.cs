using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour {

    Vector3 _birdMovement = new Vector3(-1.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(_birdMovement * Time.deltaTime);
    }
}
