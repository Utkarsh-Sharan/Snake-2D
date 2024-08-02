using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestSinglePlayerName;
    [SerializeField] private TextMeshProUGUI _bestSinglePlayerScore;

    [SerializeField] private TextMeshProUGUI _player1Name;
    [SerializeField] private TextMeshProUGUI _player2Name;
    [SerializeField] private TextMeshProUGUI _player1Score;
    [SerializeField] private TextMeshProUGUI _player2Score;

    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _quitButton;

    private void Start()
    {
        if(GameManager.Instance.GameType == GameType.SINGLE_PLAYER)
        {
            _bestSinglePlayerName.text = $"Best Player: {ScoreManager.Instance.bestPlayerName}";
            _bestSinglePlayerScore.text = $"Score: {ScoreManager.Instance.bestPlayerScore}";
        }
        else
        {
            _player1Name.text = $"Player 1: {ScoreManager.Instance.player1Name}";
            _player1Score.text = $"Score: {ScoreManager.Instance.player1Score}";
            _player2Name.text = $"Player 2: {ScoreManager.Instance.player2Name}";
            _player2Score.text = $"Score: {ScoreManager.Instance.player2Score}";
        }

        _mainMenuButton.onClick.AddListener(MainMenuButton);
        _quitButton.onClick.AddListener(QuitToDesktopButton);
    }

    private void MainMenuButton()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    private void QuitToDesktopButton()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
