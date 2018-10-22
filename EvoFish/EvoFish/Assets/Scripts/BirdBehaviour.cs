using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour {

    private Vector3 _birdMovement = new Vector3(-1.0f, 0.0f, 0.0f);
    private float _cycleTimer = 0;
    private bool detected = false;
    private float _diffDisty = 0;
    private float pos = 0;

    // Use this for initialization
    void Start () {
        _diffDisty = Mathf.Abs(GameObject.Find("Player").transform.position.y - gameObject.transform.position.y);
        pos = gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        // Get difference in difference between attached object and the player (x axis)
        float _diffDistx = gameObject.transform.position.x - GameObject.Find("Player").transform.position.x;
        print(_cycleTimer);
        if (_diffDistx <= 5.0f) {
            detected = true;
        }
        if (_cycleTimer > 8.0f) {
            detected = false;
        }
        if (detected) {
            _cycleTimer += Time.deltaTime;
            transform.Translate(-1.0f * Time.deltaTime, 0.0f, 0.0f);
            Vector3 swoop = transform.position;
            swoop.y = pos + ((Mathf.Cos(_cycleTimer * Mathf.PI / 4.0f) - 1) / 2) * _diffDisty;
            transform.position = swoop;
            detected = false;
        }
    }
}
