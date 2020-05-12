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


    public Vector3 angularVelocity;
    public float maxAngularVelocity;

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
        //Debug.Log(velocity);
        //MyAddForce(Vector3.forward * speed);

        // 가장 마지막 순서
        PhysicsAvatar();
    }

    // FixedUpdate에서 연산
    private void PhysicsAvatar()
    {
        Vector3 temp;

        OperationAngularVelocity();

        temp = velocity;

        temp = temp * Time.fixedDeltaTime;
        m_Tr.position += temp;
    }


    // F 를 일정 방향으로 주어진다.
    // F = ma;
    public void MyAddForce(Vector3 Vector)
    {
        Vector *= mass;
        velocity += Vector;

        
            Debug.Log("velocity" + velocity);
        if (UseGravity)
        {
            velocity += PhysicsManager.instance.gravity * Time.fixedDeltaTime;
            if (PhysicsManager.instance.SphereAndPlaneIntersect(this.gameObject, PhysicsManager.instance.ground))
            {
                velocity = new Vector3(velocity.x, 0, velocity.z);
            }
        }
        //Debug.Log(Vector);
        

        //Debug.Log(mass);
    }
    
    public void OperationAngularVelocity()
    {
        //Debug.Log(angularVelocity);
        //Debug.Log(m_Tr.rotation);
        //m_Tr.rotation = new Quaternion(m_Tr.rotation.eulerAngles.x + angularVelocity.x, m_Tr.rotation.y + angularVelocity.y, m_Tr.rotation.z + angularVelocity.z,m_Tr.rotation.w);

        //angularVelocity = new Vector3(angularVelocity.x * (Time.fixedDeltaTime * Time.fixedDeltaTime), angularVelocity.y * (Time.fixedDeltaTime * Time.fixedDeltaTime), angularVelocity.z * (Time.fixedDeltaTime * Time.fixedDeltaTime));
        
        m_Tr.Rotate(angularVelocity*Time.fixedDeltaTime);
        //Debug.Log(angularVelocity);
        //a.SetFromToRotation(m_Tr.rotation.eulerAngles, angularVelocity);
        //m_Tr.rotation += a;
    }
        



}
