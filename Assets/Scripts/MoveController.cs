using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    MyPhysicsV2 m_pysics;


    // Start is called before the first frame update
    void Start()
    {
        m_pysics = GetComponent<MyPhysicsV2>();
    }

    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        m_pysics.MyAddForce(Vector3.forward * speed);
    }

}
