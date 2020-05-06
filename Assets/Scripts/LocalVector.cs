using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalVector : MonoBehaviour
{
    public Vector3 eulerAngles;

    [SerializeField]
    private MeshFilter mf;
    [SerializeField]
    private Vector3[] originVector;
    [SerializeField]
    private Vector3[] newVector;

    private Transform m_Tr;
    void Start()
    {
        mf = GetComponent<MeshFilter>();
        originVector = mf.mesh.vertices;
        newVector = new Vector3[originVector.Length];
        m_Tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        eulerAngles = m_Tr.rotation.eulerAngles;
        Quaternion rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one);

        int i = 0;
        while (i < originVector.Length)
        {
            newVector[i] = m.MultiplyPoint3x4(originVector[i]);
            i++;
        }

    }



}
