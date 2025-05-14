using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectFactory
{
    GameObject CreateObject();
}

public class RedFactory : IObjectFactory
{
    public GameObject CreateObject()
    {
        GameObject obj = Object.Instantiate(Resources.Load<GameObject>("Cube"));
        obj.transform.position = new Vector3(0, 0, 0); // posición visible
        return obj;
    }
}


public class GreenFactory : IObjectFactory
{
    public GameObject CreateObject()
    {
        GameObject obj = Object.Instantiate(Resources.Load<GameObject>("Cylinder"));
        obj.transform.position = new Vector3(0, 1, 0); // posición visible
        return obj;
    }
}

public class BlueFactory : IObjectFactory
{
    public GameObject CreateObject()
    {
        GameObject obj = Object.Instantiate(Resources.Load<GameObject>("Sphere"));
        obj.transform.position = new Vector3(0, 3, 0); // posición visible
        return obj;
    }
}
public class ObjectSpawner
{
    private IObjectFactory currentFactory;

    public void SetFactory(IObjectFactory factory) => currentFactory = factory;
    public void SpawnObject() => currentFactory?.CreateObject();
}
