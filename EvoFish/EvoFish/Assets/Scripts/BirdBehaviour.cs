using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour {
    
    private float _cycleTimer = 0;
    private bool _detected = false;
    private float _diffDisty = 0;
    private float _pos = 0;

    // Use this for initialization
    void Start () {
        _diffDisty = Mathf.Abs(GameObject.Find("Player").transform.position.y - gameObject.transform.position.y);
        _pos = gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        // Get difference in difference between attached object and the player (x axis)
        float _diffDistx = gameObject.transform.position.x - GameObject.Find("Player").transform.position.x;

        if (_diffDistx <= 5.0f) {
            _detected = true;
        }
        if (_cycleTimer > 8.0f) {
            _detected = false;
        }
        if (_detected) {
            _cycleTimer += Time.deltaTime;
            transform.Translate(-1.0f * Time.deltaTime, 0.0f, 0.0f);
            Vector3 swoop = transform.position;
            swoop.y = _pos + ((Mathf.Cos(_cycleTimer * Mathf.PI / 4.0f) - 1) / 2) * _diffDisty;
            transform.position = swoop;
            _detected = false;
        }
    }
}
