using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour {

    Vector3 _birdMovement = new Vector3(-1.0f, 0.0f, 0.0f);
    float timer = 0;
    bool detected = false;
    float _diffDisty = 0;
    float pos = 0;

    // Use this for initialization
    void Start () {
        _diffDisty = Mathf.Abs(GameObject.Find("Player").transform.position.y - gameObject.transform.position.y);
        pos = gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        // Get difference in difference between attached object and the player (x axis)
        float _diffDistx = Mathf.Abs(GameObject.Find("Player").transform.position.x - gameObject.transform.position.x);
        if (_diffDistx <= 5.0f || _diffDistx >= 5.0f)
        {
            timer += Time.deltaTime;
            // Cat detects the player
            transform.Translate(-1.0f * Time.deltaTime, 0.0f, 0.0f);
            Vector3 swoop = transform.position;
            swoop.y = pos + ((Mathf.Cos(timer * Mathf.PI / 4.0f) - 1) / 2) * _diffDisty;
            transform.position = swoop;
            print(timer);
        }
    }
}
