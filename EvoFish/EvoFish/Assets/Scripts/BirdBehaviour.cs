using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{

    //for Animation
    [SerializeField]
    private Animator anim;
    [SerializeField]
    GameObject player;

    private float _cycleTimer = 0;
    private bool _detected = false;
    private float _diffDisty = 0;
    private float _pos = 0;
    private float time = 1;

    // Use this for initialization
    void Start()
    {
        _pos = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Get difference in difference between attached object and the player (x axis)
        float _diffDistx = gameObject.transform.position.x - player.transform.position.x;

        if (_diffDistx <= 5.0f && !_detected && player.GetComponent<PlayerController>().isGrounded)
        {
            _diffDisty = Mathf.Abs(player.transform.position.y -2.0f  - gameObject.transform.position.y);

            _detected = true;
        }
        if (_cycleTimer > 4.0f && _detected)
        {
            anim.SetBool("attack", false);
            _detected = false;
        }
        if (_detected)
        {
            anim.SetBool("attack", true);
            _cycleTimer += Time.deltaTime;
            transform.Translate(-1.0f * Time.deltaTime, 0.0f, 0.0f);
            Vector3 swoop = transform.position;
            swoop.y = _pos + ((Mathf.Cos(_cycleTimer * Mathf.PI / time) - 1) / 2) * _diffDisty;
            transform.position = swoop;
            _detected = false;
        }
    }
}
