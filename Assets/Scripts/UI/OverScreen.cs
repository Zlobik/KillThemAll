using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LoadScene))]
public class OverScreen : MonoBehaviour
{
    [SerializeField] private float _fadeSeconds;
    [SerializeField] private CanvasGroup _gameOverScreen;
    [SerializeField] private float _secondsBeforeGoToMainMenu;

    private LoadScene _loadMenu;

    private void Start()
    {
        _loadMenu = GetComponent<LoadScene>();
    }

    public void ShowOverScreen()
    {
        StartCoroutine(FadeInOverScreen());
    }

    private IEnumerator FadeInOverScreen()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _gameOverScreen.DOFade(1, _fadeSeconds);

        yield return new WaitForSeconds(_secondsBeforeGoToMainMenu);
        _loadMenu.Load();
    }
}
