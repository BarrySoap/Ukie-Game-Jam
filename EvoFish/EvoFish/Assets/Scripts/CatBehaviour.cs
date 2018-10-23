using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour
{
    //For Animation
    [SerializeField]
    private Animator anim;

    private float _moveSpeed = 1.3f;
    private bool _detected = false;
    private float _frequency = 1.02f;  // Speed of sine movement
    private float _magnitude = 0;   // Size of sine movement
    private Vector3 _axis;
    private float _diffDistX = 0;
    private Vector3 _pos;
    private bool catJumped = false;
    private float _cycleTimer = 0;
    private float oriY = 0;
    private bool awake = true;

    public void SetPos(Vector3 newPos)
    {
        _pos = newPos;
        awake = false;
    }

    // Use this for initialization
    void Start()
    {
        _pos = transform.position;
        _axis = new Vector3(-1.0f, 0.0f, 0.0f);
        oriY = _pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (awake)
        {
            _diffDistX = gameObject.transform.position.x - GameObject.Find("Player").transform.position.x;
            if (!catJumped && _diffDistX <= 5.0f)
            {
                _detected = true;
                _magnitude = Mathf.Abs(GameObject.Find("Player").transform.position.x - gameObject.transform.position.x);
                catJumped = true;
            }

            if (_detected)
            {
                anim.SetBool("Attack", true);
                _cycleTimer += Time.deltaTime;
                _pos.y -= (oriY * Time.deltaTime * _moveSpeed);
                //_pos.y -= (1.0f * Time.deltaTime * _moveSpeed);
                transform.position = _pos + _axis * Mathf.Sin((Mathf.PI / 2.0f) * _cycleTimer * _frequency) * _magnitude;
            }
        }
    }
}
