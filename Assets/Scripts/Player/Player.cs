using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _secondsBeforeNewShot;
    [SerializeField] private GameObject _bulletTemplate;
    [SerializeField] private Transform _bulletsParent;

    private bool _isPressedMouseButton = false;
    private float _elapsedTime = 0;
    private float _health;

    public float Health => _health;

    public event UnityAction<int> ChangeScore;
    public event UnityAction<float> ChangeHealth;

    private void Start()
    {
        _health = _maxHealth;

        if (PlayerPrefs.HasKey("PlayerHealth"))
            _health = PlayerPrefs.GetFloat("PlayerHealth");
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        ChangeHealth?.Invoke(_health);

        if (_health <= 0)
            gameObject.SetActive(false);
    }

    public void AddScore(int score)
    {
        ChangeScore?.Invoke(score);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPressedMouseButton = true;
            _elapsedTime = _secondsBeforeNewShot;
        }
        else if (Input.GetMouseButtonUp(0))
            _isPressedMouseButton = false;

        if (_isPressedMouseButton)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _secondsBeforeNewShot)
            {
                _elapsedTime = 0;
                Shot();
            }
        }
    }

    private void Shot()
    {
        GameObject bullet = Instantiate(_bulletTemplate, _bulletsParent);
        bullet.transform.position = _bulletsParent.position;
        bullet.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);
    }
}
