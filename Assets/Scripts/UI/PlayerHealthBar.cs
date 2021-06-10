using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(OverScreen))]
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _doValueSeconds = 0.15f;

    private Slider _slider;
    private OverScreen _overScreen;

    private void Start()
    {
        _overScreen = GetComponent<OverScreen>();
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.Health;
        _slider.value = _slider.maxValue;
    }

    private void OnEnable()
    {
        _player.ChangeHealth += SetHealth;
    }

    private void OnDestroy()
    {
        _player.ChangeHealth -= SetHealth;
    }

    private void SetHealth(float health)
    {
        _slider.DOValue(health, _doValueSeconds);

        if (health <= 0)
            _overScreen.ShowOverScreen();
    }


}
