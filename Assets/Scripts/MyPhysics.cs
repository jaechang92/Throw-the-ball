using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPhysics : MonoBehaviour
{
    /// <summary>
    /// 이 운동은 구체와 평면간의 물리충돌 검출이다.
    /// </summary>

    [Tooltip("m/s")]
    private float m_gravity = 9.8f;

    private Transform m_tr;
    private SphereCollider myC;


    public bool isCrashed = false;

    private float m_radius;

    private void Start()
    {
        m_tr = GetComponent<Transform>();

        myC = GetComponent<SphereCollider>();
        m_radius = myC.radius;
    }

    private void FixedUpdate()
    {
        Debug.Log(myC.bounds.SqrDistance(Vector3.zero));
        Debug.Log(m_radius * m_radius);
        if (myC.bounds.SqrDistance(Vector3.zero) <= m_radius* m_radius)
        {
            
        }
        else
        {
            m_tr.Translate(Vector3.up * -1 * Time.fixedDeltaTime);

        }
    }


    // 충돌검사는 매 FixedTime마다 검출하고 A오브젝트와 A를 제외한 모든 상대 오브젝트를 검사한다.
    // B오브젝트는 콜라이더를 가지고있는 모든 물체이고
    // GameStart 될때 Awake에서 할당 시켜준다.

    public bool CheckCrash(GameObject A,GameObject B)
    {


        //if  (OperationMinMax(A,"Min") > OperationMinMax(B,"Max") 
        //    && OperationMinMax(A, "Max") < OperationMinMax(B, "Min")
        //    )
        //{
        //    isCrashed = true;
        //}


        return isCrashed;
    }

    //private Vector3 OperationMinMax(GameObject objectVector, string str)
    //{
    //    Vector3 temp;
    //    if (str == "Min")
    //    {// 최소값
    //        temp = new Vector3(objectVector.transform.position.x - objectVector.transform.localScale.x / 2,
    //                           objectVector.transform.position.y - objectVector.transform.localScale.y / 2,
    //                           objectVector.transform.position.z - objectVector.transform.localScale.z / 2
    //                          );
    //    }
    //    else if(str == "Max")
    //    {// 최대값
    //        temp = new Vector3(objectVector.transform.position.x + objectVector.transform.localScale.x / 2,
    //                           objectVector.transform.position.y + objectVector.transform.localScale.y / 2,
    //                           objectVector.transform.position.z + objectVector.transform.localScale.z / 2
    //                          );
    //    }

    //    //차후 수정
    //    return temp;
    //}



    //private bool SpherePlane(SphereCollider S, Object plane)

    //{

    //    //구와 평면 사이의 거리

    //    float Dist = D3DXVec3Dot(S.center, &pP->n) + pP->d;



    //    //거리 비교   

    //    if (Mathf.Abs(Dist) <= pS->Radius)

    //        return true;



    //    return false;

    //}


}
