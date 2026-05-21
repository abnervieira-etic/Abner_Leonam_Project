using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab = new GameObject[4];
    [SerializeField] private int poolSize;
    Queue<GameObject> pool = new Queue<GameObject>();
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    private Vector2 spawnPos;

    public static ObjectPooler Instance;

    private void Awake()
    {
       Instance = this;
    }

    void Update()
    {

    }
    

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab[UnityEngine.Random.Range(0, prefab.Length)], spawnPos, Quaternion.identity);
            obj .SetActive(false);  
            pool.Enqueue(obj);

        }

        PullObject(spawnPos);
    }

    public void PullObject(Vector3 position)
    {
     if (pool.Count > 0)
     {
         GameObject obj = pool.Dequeue();
         obj.SetActive(true);
         obj.transform.position = position;
     }
     else
     {
        GameObject obj = Instantiate(prefab[UnityEngine.Random.Range(0, prefab.Length)], position, Quaternion.identity);
        obj.transform.position = position;
     }
    }


    public void ReturnObject(GameObject obj)
    {
        pool.Enqueue(obj);
        obj.SetActive(false);
    }

}