using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalVector : MonoBehaviour
{
    public Matrix4x4 matrix4X4;
    private Transform m_tr;

    public Vector3 localV;

    // Start is called before the first frame update
    void Start()
    {
        m_tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        localV = m_tr.position;
        Debug.Log(m_tr.position);

        //Debug.Log(m_tr.eulerAngles.y);
        Debug.Log(Mathf.Cos(Mathf.Deg2Rad * m_tr.eulerAngles.y)*2);
    }
}
