using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private Transform _player;
    [SerializeField] private bool _isShootPlayer = true;

    public float Damage => _damage;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerDamage") && _isShootPlayer)
            _damage = PlayerPrefs.GetFloat("PlayerDamage");

        transform.rotation = _player.rotation;
    }

    private void Update()
    {
        if (_isShootPlayer)
            transform.localPosition = Vector3.MoveTowards(transform.position, transform.right, _speed * Time.deltaTime);
        else
            transform.localPosition = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isShootPlayer && collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (!_isShootPlayer && collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
