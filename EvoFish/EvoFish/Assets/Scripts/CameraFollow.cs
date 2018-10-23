using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 baseLevel = new Vector3(0.0f, 0.0f, 0.0f);
    // Use this for initialization
    void Awake()
    {
        baseLevel = transform.position;
        baseLevel.x = player.position.x + 5;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = baseLevel + new Vector3(player.position.x, 0, 0);
    }
}

