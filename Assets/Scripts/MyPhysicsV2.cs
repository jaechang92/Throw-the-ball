using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 이 스크립트를 포함하고 있는 물체는 움직이는 물체이다.
public class MyPhysicsV2 : MonoBehaviour
{
    [SerializeField]
    private float m_mass = 1;
    private float mass
    {
        get
        {
            return m_mass;
        }

        set
        {
            if (value <=0)
            {
                value = 0.0001f;
            }
            m_mass = value;
        }
    }
    public float Drag;
    public float AngularDrag;
    public bool UseGravity;
    
    public Vector3 velocity { get; set; }
    [SerializeField]
    private Transform m_Tr;

    void Start()
    {
        Debug.Log("Mass Get " + mass);
        m_Tr = GetComponent<Transform>();
        testRB = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
        
    }

    private Rigidbody testRB;

    
    private void FixedUpdate()
    {
        Debug.Log(velocity);
        //MyAddForce(Vector3.forward * speed);

        // 가장 마지막 순서
        PhysicsAvatar();
    }

    // FixedUpdate에서 연산
    private void PhysicsAvatar()
    {
       

        Vector3 temp;
        
        temp = velocity;

        temp = temp * Time.fixedDeltaTime;
        m_Tr.position += temp;
    }


    // F 를 일정 방향으로 주어진다.
    // F = ma;
    public void MyAddForce(Vector3 Vector)
    {
        //Vector /= mass;
        velocity += Vector * Time.fixedDeltaTime;

        if (UseGravity)
        {
            velocity += PhysicsManager.instance.gravity * Time.fixedDeltaTime;

            if (PhysicsManager.instance.SphereAndPlaneIntersect(this.gameObject, PhysicsManager.instance.ground))
            {
                velocity = new Vector3(velocity.x, 0, velocity.z);
            }
        }
        

        //Debug.Log(mass);
    }


}
