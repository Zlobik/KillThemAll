using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{
    [SerializeField] private float _secondsBeforeNewShot;
    [SerializeField] private GameObject _bulletTemplate;
    [SerializeField] private Transform _bulletsParent;

    private float _distanceOnStart;
    private float _currentDistance;
    private float _elapsedTime;

    private void Start()
    {
        _distanceOnStart = Vector3.Distance(transform.position, Target.transform.position);
    }

    private void Update()
    {
        _currentDistance = Vector3.Distance(transform.position, Target.transform.position);

        if (_currentDistance >= _distanceOnStart / 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        }
        else
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _secondsBeforeNewShot)
            {
                _elapsedTime = 0;
                GameObject bullet = Instantiate(_bulletTemplate, _bulletsParent);
                bullet.SetActive(true);
                bullet.transform.position = transform.position;
                bullet.gameObject.SetActive(true);
            }
        }
    }
}
