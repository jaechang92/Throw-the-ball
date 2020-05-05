using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalVector : MonoBehaviour
{

    public Vector3 a;
    public Vector3 b;
    public Vector3 c;

    Vector3 side1;
    Vector3 side2;

    public Vector3 normal;
    public Collision col;
    void Start()
    {
        a = this.gameObject.GetComponent<Collider>().bounds.center;
        b = new Vector3(, Mathf.Sin(this.gameObject.GetComponent<Transform>().rotation.x), Mathf.Cos(this.gameObject.GetComponent<Transform>().rotation.x));

        side1 = b - a;
        side2 = c - a;

        normal = Vector3.Cross(side1, side2);
        normal /= normal.magnitude;

        Collision test = gameObject.GetComponent<Collider>().

        col = GetComponent<Collision>();
        Debug.Log(col.contacts[0]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionStay(Collision col)
    {
        ContactPoint cp = col.contacts[0]; //첫번째 충돌한 벽에 대한 충돌자

        //cp.normal은 그 충돌자에 대한 법선벡터를 뜻한다.

        float dot = Mathf.Abs(Vector3.Dot(Camera.main.transform.forward, cp.normal));
    }

}
