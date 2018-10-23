using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehaviour : MonoBehaviour
{

    //for Animation
    [SerializeField]
    private Animator anim;

    private float _diffDistx = 0;
    private bool _detected = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Get difference in difference between attached object and the player (x axis)
       _diffDistx = gameObject.transform.position.x - GameObject.Find("Player").transform.position.x;

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
        if (col.gameObject.tag == "Player")
        {
            if (_diffDistx < 0.0f)
            {
                Vector3 temp = gameObject.transform.localScale;
                temp.x *= -1;
                gameObject.transform.localScale = temp;
            }
            anim.SetBool("attack", true);
        }
    }
}
