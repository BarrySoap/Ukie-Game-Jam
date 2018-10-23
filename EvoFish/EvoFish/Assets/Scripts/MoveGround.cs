using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField]
    Transform otherBackground;
    [SerializeField]
    Transform camera;

    public float temp;

    // Use this for initialization
    void Start()
    {
        temp = camera.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x + 9.085f == (Mathf.Round(camera.position.x) - 7.8f) && otherBackground.position.x < camera.position.x)
        {
            // Move the platform by double the width of a platform on the x axis. (hacky lol)
            gameObject.transform.Translate(new Vector3(22.7125f, 0.0f, 0.0f));
        }
        if (otherBackground.position.x == Mathf.Round(camera.position.x - 8) && gameObject.transform.position.x < camera.position.x)
        {
            gameObject.transform.Translate(new Vector3(36.0f, 0.0f, 0.0f));
        }
    }
}
