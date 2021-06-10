using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private int _poolCapacity;

    private List<GameObject> _pool = new List<GameObject>();

    private int _previousRandomIndex;

    public void Initialize()
    {
        for (int i = 0; i < _poolCapacity; i++)
        {
            int randomIndex = Random.Range(0, _templates.Length);

            GameObject spawned = Instantiate(_templates[randomIndex], transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }
}
