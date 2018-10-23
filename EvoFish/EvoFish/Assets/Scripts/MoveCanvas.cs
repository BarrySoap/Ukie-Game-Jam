using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvas : MonoBehaviour
{

    Camera m_MainCamera;
    int m_width = 0;
    int m_height = 0;

    // Use this for initialization
    void Start()
    {
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        m_width = m_MainCamera.pixelWidth / 8;
        m_height = m_MainCamera.pixelHeight - (m_MainCamera.pixelHeight / 8);

        GameObject.Find("ControlsBorder").transform.position = new Vector3(m_width, m_height, 0.0f);
        GameObject.Find("Level1").transform.position = new Vector3(m_width, m_height, 0.0f);
    }
}
