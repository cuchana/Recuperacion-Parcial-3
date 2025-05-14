using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ProjectilePool : MonoBehaviour
{
    protected Queue<GameObject> pool = new Queue<GameObject>();
    public GameObject projectilePrefab;
    public int poolSize = 10;

    protected virtual void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public virtual GameObject GetProjectile(Vector3 position, Quaternion rotation)
    {
        GameObject obj = pool.Dequeue();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        pool.Enqueue(obj);
        return obj;
    }
}
