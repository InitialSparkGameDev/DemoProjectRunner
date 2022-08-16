using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverScreen;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _quitButton.onClick.AddListener(OnQuitButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }
    private void OnDisable()
    {
        _player.Died -= OnDied;
        _quitButton.onClick.RemoveListener(OnQuitButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }
    private void Start()
    {
        _gameOverScreen = GetComponent<CanvasGroup>();

        _gameOverScreen.alpha = 0;

    }
    private void OnDied()
    {
        _gameOverScreen.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
