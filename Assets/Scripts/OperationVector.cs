using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationVector : MonoBehaviour
{
    public Vector3 eulerAngles;

    [SerializeField]
    private MeshFilter mf;
    [SerializeField]
    private Vector3[] originVector;
    [SerializeField]
    private Vector3[] newVector;

    private Transform m_Tr;
    
    private Plane ground;

    void Start()
    {
        mf = GetComponent<MeshFilter>();
        originVector = mf.mesh.vertices;
        newVector = new Vector3[originVector.Length];
        m_Tr = GetComponent<Transform>();

        //if (this.gameObject.GetComponent<Collider>() != null)
        //{
        //    PhysicsManager.instance.AddList(this.gameObject);
        //}

    }

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
        NormalVector();
        
        //Debug.Log(CheckSpherePlane(this.gameObject, ground));




    }


    // 어떠한 평면
    [SerializeField]
    private Vector3 a;
    [SerializeField]
    private Vector3 b;
    [SerializeField]
    private Vector3 c;

    public Vector3 normalVector3;
    [SerializeField]
    Vector3 side1;
    [SerializeField]
    Vector3 side2;

    public Vector3 NormalVector()
    {
        a = newVector[0];
        b = newVector[originVector.Length/2-1];
        c = newVector[originVector.Length-1];


        side1 = b - a;
        side2 = c - a;

        normalVector3 = Vector3.Cross(side1, side2);
        //Debug.Log(normalVector3);
        normalVector3 /= normalVector3.magnitude;
        
        return normalVector3;
    }



    public bool CheckSpherePlane(GameObject sphere,Plane plane)
    {
        float radius;
        radius = sphere.GetComponent<SphereCollider>().radius;
        Vector3 center;
        center = sphere.GetComponent<SphereCollider>().center;

        float distance;
        distance = plane.GetDistanceToPoint(sphere.GetComponent<Transform>().position);

        if (radius >= distance)
        {
            return true;
        }

        return false;
    }




}
