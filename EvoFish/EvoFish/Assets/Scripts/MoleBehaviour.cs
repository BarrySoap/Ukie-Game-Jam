using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehaviour : MonoBehaviour
{

    //for Animation
    [SerializeField]
    private Animator anim;

    private bool _detected = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Get difference in difference between attached object and the player (x axis)
        float _diffDistx = gameObject.transform.position.x - GameObject.Find("Player").transform.position.x;

        if (_diffDistx <= 5.0f)
        {
            _detected = true;
        }
        if (_detected)
        {
            anim.SetBool("see", true);
            _detected = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        anim.SetBool("attack", true);
    }
}
