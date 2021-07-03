using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Player player;

    private CanvasGroup gameOverGroup;

    private void OnEnable()
    {
        player.Died += OnDied;
        restartButton.onClick.AddListener(OnRestartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }
    private void OnDisable()
    {
        player.Died -= OnDied;
        restartButton.onClick.RemoveListener(OnRestartButtonClick);
        exitButton.onClick.RemoveListener(OnExitButtonClick);
    }
    private void Start()
    {
        gameOverGroup = GetComponent<CanvasGroup>();
        gameOverGroup.alpha = 0;
    }

    private void OnDied()
    {
        gameOverGroup.alpha = 1;
        //Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}