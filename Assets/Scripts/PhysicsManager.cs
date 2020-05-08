using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public static PhysicsManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);
    }


    public List<GameObject> objectPool;
    public List<Transform> trPool;


    public GameObject ball;
    public GameObject ground;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void AddList(GameObject obj)
    {
        objectPool.Add(obj);
        Transform temp = obj.GetComponent<Transform>();
        trPool.Add(temp);
    }

    public void RemoveList(GameObject obj)
    {
        objectPool.Remove(obj);
        trPool.Remove(obj.transform);
    }

    public Vector3 gravity = new Vector3(0, -9.8f, 0);
    private Vector3 downV = Vector3.down;
    public float nowGravity = 0.0f;
    private void FixedUpdate()
    {

    }

    public bool SphereAndPlaneIntersect(GameObject sphere, GameObject plane)
    {

        if (sphere.transform.position.y - plane.transform.position.y <= sphere.GetComponent<SphereCollider>().radius)
        {
            Debug.Log("여기도도도도도도도");
            Debug.Log(sphere.transform.position.y - plane.transform.position.y);
            return true;
        }

        return false;
    }

    
}
