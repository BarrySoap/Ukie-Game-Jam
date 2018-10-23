using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField]
    Transform otherPlatform;
    [SerializeField]
    Transform camera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("spam");
        if (Mathf.Round(gameObject.transform.position.x) == Mathf.Round(camera.position.x) &&
            otherPlatform.position.x < camera.position.x)
        {
            // Move the platform by double the width of a platform on the x axis. (hacky lol)
            otherPlatform.Translate(new Vector3(36.0f, 0.0f, 0.0f));
        }
        if (Mathf.Round(otherPlatform.position.x) == Mathf.Round(camera.position.x) &&
            gameObject.transform.position.x < camera.position.x)
        {
            gameObject.transform.Translate(new Vector3(36.0f, 0.0f, 0.0f));
        }
    }
}
