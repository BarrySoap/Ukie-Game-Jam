using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour {

    Vector3 _catMovement = new Vector3(-1.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get difference in difference between attached object and the player (x axis)
        float _diffDist = Mathf.Abs(GameObject.Find("Player").transform.position.x - gameObject.transform.position.x);
        if (_diffDist <= 2.0f)
        {
            // Cat detects the player
            transform.Translate(_catMovement * Time.deltaTime);
        }
    }
}
