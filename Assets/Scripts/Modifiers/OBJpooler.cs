using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJpooler : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab = new GameObject[6];
    [SerializeField] private int poolSize;
    Queue<GameObject> pool = new Queue<GameObject>();
    public Vector2 spawnPos;

    public static OBJpooler Instance;

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

    }

    public GameObject PullObject(Vector3 position)
    {
    GameObject obj;
    
    if (pool.Count > 0)
    {
        obj = pool.Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
    }
    else
    {
        obj = Instantiate(prefab[UnityEngine.Random.Range(0, prefab.Length)], position, Quaternion.identity);
        obj.transform.position = position;
    }

    return obj;
    }


    public void ReturnObject(GameObject obj)
    {
        pool.Enqueue(obj);
        obj.SetActive(false);
    }

}