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
    private float speed;
    public float RPM;
    public float m_ForceOfStartRotation;

    public Vector3 targetTr;

    public bool forwardRotation;

    public Vector3 spinAngle;

    //private Rigidbody m_rb;
    private MyPhysicsV2 m_rb;
    private float radius;
    private float magnusForce;
    private float volume;
    [SerializeField]
    private float constNum;
    [SerializeField]
    private Vector3 foreceDirection;
    private float angleSpeed;

    private float time = 0;

    public int count = 0;
    public Vector3 angleV;

    public bool isStart = false;

    public Vector3 originPos;
    public Quaternion originRot;

    public void Init()
    {
        m_rb.maxAngularVelocity = 1000000;

        angleSpeed = RPM / 60 * Mathf.PI * 2;
        if (forwardRotation)
        {
            angleSpeed = -angleSpeed;
        }

        speed = m_StartSpeed * 10 / 36;
        m_rb.velocity = targetTr.normalized * speed;
        if (angleSpeed > m_rb.maxAngularVelocity)
        {
            angleSpeed = m_rb.maxAngularVelocity;
        }
        m_rb.angularVelocity = spinAngle * angleSpeed;
        Debug.LogError(spinAngle * angleSpeed);
        // x 축회전은 상하
        // y 축회전은 전후
        // z 축회전은 좌우

        //m_rb.AddTorque(Vector3.left * m_StartSpin);
        //m_rb.AddForce(Vector3.forward * m_StartSpeed);

        time = 0;

    }

    void Awake()
    {
        m_Tr = GetComponent<Transform>();

        if (GetComponent<MyPhysicsV2>() == null)
        {
            this.gameObject.AddComponent<MyPhysicsV2>();
        }
        m_rb = GetComponent<MyPhysicsV2>();


        radius = m_Tr.localScale.x * 0.5f;
        volume = Mathf.PI * 4 / 3 * radius * radius * radius;
        //constNum = 1;

        originPos = this.gameObject.transform.position;
        originRot = this.gameObject.transform.rotation;


        

    }



    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(magnusForce);
        CreateCircle();


    }

    void FixedUpdate()
    {

        if (isStart)
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

            Debug.LogError(foreceDirection);
            m_rb.MyAddForce(foreceDirection * magnusForce);
            Debug.LogError(foreceDirection.z * magnusForce);
            //Debug.Log(spinAngle * angleSpeed);
            angleV = m_rb.angularVelocity;
            //Debug.Log(m_rb.angularVelocity);
        }

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
    
    public void StartBtn()
    {
        Init();
        isStart = true;
    }

    public void ResetBtn()
    {
        isStart = false;
        m_Tr.position = originPos;
        m_Tr.rotation = originRot;

        m_rb.velocity = Vector3.zero;
        m_rb.angularVelocity = Vector3.zero;
        checkZ = 0;

        foreach (var item in objPool)
        {
            Destroy(item);
        }
        objPool.Clear();
    }


    public GameObject prefab;
    private float checkZ = 0;
    public List<GameObject> objPool;
    public void CreateCircle()
    {
        if (m_Tr.position.z > checkZ)
        {
            GameObject obj= Instantiate(prefab, m_Tr.position,prefab.transform.rotation);
            obj.transform.position = new Vector3 (0, obj.transform.position.y, obj.transform.position.z);
            objPool.Add(obj);
            checkZ++;
        }

        
    }
       


}
