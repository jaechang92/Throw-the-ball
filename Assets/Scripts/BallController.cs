using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 마그누스 효과
/// F = 1/2pwrVAI
/// 
/// F = 마그누스 힘
/// p = 유체의 밀도
/// w = 회전각속도
/// r = 공의 반지름
/// V = 공의 속도
/// A = 공의 단면적
/// I = 상수
/// </summary>



public class BallController : MonoBehaviour
{
    public Transform m_Tr;
    [Tooltip("KM/H")]
    public float m_StartSpeed;
    public float RPM;
    public float m_ForceOfStartRotation;

    public Vector3 targetTr;

    public bool forwardRotation;

    public Vector3 spinAngle;

    private Rigidbody m_rb;
    private float radius;
    private float magnusForce;
    private float volume;
    [SerializeField]
    private float constNum;
    private Vector3 foreceDirection;
    private float angleSpeed;

    private float time = 0;

    public int count = 0;
    public Vector3 angleV;
    void Awake()
    {
        m_Tr = GetComponent<Transform>();

        if (GetComponent<Rigidbody>() == null)
        {
            this.gameObject.AddComponent<Rigidbody>();
        }
        m_rb = GetComponent<Rigidbody>();


        radius = m_Tr.localScale.x * 0.5f;
        volume = Mathf.PI * 4 / 3 * radius * radius * radius;
        //constNum = 1;

        angleSpeed = RPM / 60 * Mathf.PI * 2;

    }

    void Start()
    {
        if (forwardRotation)
        {
            angleSpeed = -angleSpeed;
        }


        //시속 100km/h 이면 100000m/h 이고 1000m/ 36s
        m_StartSpeed = m_StartSpeed * 10 / 36;
        m_rb.velocity = targetTr.normalized * m_StartSpeed;
        m_rb.angularVelocity = spinAngle * angleSpeed;


        // x 축회전은 상하
        // y 축회전은 전후
        // z 축회전은 좌우

        //m_rb.AddTorque(Vector3.left * m_StartSpin);
        //m_rb.AddForce(Vector3.forward * m_StartSpeed);
        m_rb.maxAngularVelocity = 1000000;
    }


    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(magnusForce);

    }

    void FixedUpdate()
    {
        //angleSpeed = Mathf.Sqrt(Mathf.Pow(m_rb.angularVelocity.x, 2) + Mathf.Pow(m_rb.angularVelocity.y, 2) + Mathf.Pow(m_rb.angularVelocity.z, 2));
        
        foreceDirection = m_Tr.TransformVector(new Vector3(m_rb.angularVelocity.y, -m_rb.angularVelocity.x, m_rb.angularVelocity.z));
        foreceDirection = foreceDirection.normalized;
        angleSpeed = m_rb.angularVelocity.magnitude;
        //Debug.Log(constNum);
        //Debug.Log(angleSpeed);
        //Debug.Log(volume);
        //Debug.Log(radius);
        magnusForce = 0.5f * constNum * angleSpeed * volume * radius;
        magnusForce = Mathf.Abs(magnusForce);
        

        m_rb.AddForce(foreceDirection * magnusForce);

        angleV = m_rb.angularVelocity;
        


    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("magnusForce = " + magnusForce);
        Debug.Log("비거리 = " + m_Tr.position.z);
        Debug.Log("도착 좌표 = " + m_Tr.position.x + ",   " + m_Tr.position.y);
        // 1시간 60분 1분은 60초
        // 1시간은 3600초
        //
        Debug.Log("시간 = " + time);
        Debug.Log("속도 = " + m_Tr.position.z / time * 3.6);
        
    }


    void OnTriggerEnter()
    {
        count++;
        Debug.Log(count);
    }
    

    
}
