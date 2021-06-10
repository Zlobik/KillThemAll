using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(OverScreen))]
public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Player _player;
    [SerializeField] private int _scoreToFinishPanel;

    private int _score = 0;
    private OverScreen _overScreen;

    private void Start()
    {
        _overScreen = GetComponent<OverScreen>();
    }

    private void OnEnable()
    {
        _player.ChangeScore += ChangeScore;
    }

    private void OnDisable()
    {
        _player.ChangeScore -= ChangeScore;
    }

    private void ChangeScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();

        if (_score >= _scoreToFinishPanel)
            _overScreen.ShowOverScreen();
    }
}
