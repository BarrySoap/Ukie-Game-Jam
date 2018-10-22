using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 baseLevel = new Vector3(0.0f, 0.0f, 0.0f);
    // Use this for initialization
    void Start()
    {
        baseLevel.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = baseLevel + new Vector3(player.position.x, 0, 0);
    }
}
