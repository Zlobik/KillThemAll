using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<Transform> _objects = new List<Transform>();

    public void Add(Transform @object)
    {
        _objects.Add(@object);
    }
}
