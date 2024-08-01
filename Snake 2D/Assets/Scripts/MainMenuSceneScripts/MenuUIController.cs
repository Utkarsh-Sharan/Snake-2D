using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private GameObject _menuUIHolder;
    [SerializeField] private GameObject _singlePlayerUIHolder;
    [SerializeField] private GameObject _coOpUIHolder;
    [SerializeField] private GameObject _highScoreUIHolder;

    [SerializeField] private TextMeshProUGUI _currentPlayerName;
    [SerializeField] private TextMeshProUGUI _bestPlayerName;
    [SerializeField] private TextMeshProUGUI _bestPlayerScore;

    [SerializeField] private Button _singlePlayerButton;
    [SerializeField] private Button _coOpButton;
    [SerializeField] private Button _highScoreButton;
    [SerializeField] private Button _singlePlayerPlayButton;
    [SerializeField] private Button _coOpPlayButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _quitButton;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(Sounds.BACKGROUND_MUSIC);

        _singlePlayerButton.onClick.AddListener(OpenSinglePlayerNameInputField);
        _coOpButton.onClick.AddListener(OpenCoOpPlayersNameInputField);
        _highScoreButton.onClick.AddListener(OpenHighScore);
        _backToMenuButton.onClick.AddListener(CloseHighScore);

        _singlePlayerPlayButton.onClick.AddListener(OpenSinglePlayerGameScene);
        _coOpPlayButton.onClick.AddListener(OpenCoOpGameScene);

        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OpenSinglePlayerNameInputField()
    {
        GameManager.Instance.GameType = GameType.SINGLE_PLAYER;
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

        _menuUIHolder.SetActive(false);
        _singlePlayerUIHolder.SetActive(true);
    }

    private void OpenCoOpPlayersNameInputField()
    {
        GameManager.Instance.GameType = GameType.CO_OP;
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

        _menuUIHolder.SetActive(false);
        _coOpUIHolder.SetActive(true);
    }

    private void OpenHighScore()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

        ScoreManager.Instance.LoadPlayerData();
        _bestPlayerName.text = $"Best Player: {ScoreManager.Instance.bestPlayerName}";
        _bestPlayerScore.text = $"Score: {ScoreManager.Instance.bestPlayerScore}";

        _menuUIHolder.SetActive(false);
        _highScoreUIHolder.SetActive(true);
    }

    private void CloseHighScore()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

        _highScoreUIHolder.SetActive(false);
        _menuUIHolder.SetActive(true);
    }

    private void OpenSinglePlayerGameScene()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

        ScoreManager.Instance.currentPlayer1Name = _currentPlayerName.text;
        SceneManager.LoadScene(1);
    }

    private void OpenCoOpGameScene()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

        ScoreManager.Instance.currentPlayer1Name = _currentPlayerName.text;
        SceneManager.LoadScene(2);
    }

    private void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
