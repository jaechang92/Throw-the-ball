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


    public bool SphereAndPlaneIntersect(GameObject sphere, GameObject plane)
    {



        return false;
    }

}
