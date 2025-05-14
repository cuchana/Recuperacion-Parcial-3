using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUI : MonoBehaviour
{
    private ObjectSpawner spawner = new ObjectSpawner();

    void Start()
    {
        spawner.SetFactory(new RedFactory());
    }

    public void SetRed() => spawner.SetFactory(new RedFactory());
    public void SetGreen() => spawner.SetFactory(new GreenFactory());
    public void SetBlue() => spawner.SetFactory(new BlueFactory());
    public void Spawn() => spawner.SpawnObject();
}