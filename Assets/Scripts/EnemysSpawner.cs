using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnParent;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Pool _pool;
    [SerializeField] private Map _map;

    private Transform[] _spawnPoints;
    private string _saveName = "RespawnSeconds";

    private void Start()
    {
        if (PlayerPrefs.HasKey(_saveName))
            _secondsBetweenSpawn = PlayerPrefs.GetFloat(_saveName);

        _pool.Initialize();
        _spawnPoints = new Transform[_spawnParent.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = _spawnParent.GetChild(i);

        StartCoroutine(Spawn());

    }

    private IEnumerator Spawn()
    {
        var timeBeforeRespawn = new WaitForSeconds(_secondsBetweenSpawn);

        while (true)
        {
            if (_pool.TryGetObject(out GameObject spawned))
            {
                var spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

                spawned.transform.position = spawnPosition.position;
                _map.Add(spawned.transform);
                spawned.SetActive(true);
            }

            yield return timeBeforeRespawn;
        }
    }
}
