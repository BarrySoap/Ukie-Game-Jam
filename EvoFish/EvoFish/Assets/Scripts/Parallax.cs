using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    
    float playerSpeed;
    private float _speed = 0;

	// Use this for initialization
	void Start () {
        playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().runSpeed;
        _speed = playerSpeed * 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(new Vector3(_speed, 0.0f, 0.0f) * Time.deltaTime);
	}
}
