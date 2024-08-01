using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MenuUIController : MonoBehaviour
{
    //ui holders
    [SerializeField] private GameObject _menuUIHolder;
    [SerializeField] private GameObject _singlePlayerUIHolder;
    [SerializeField] private GameObject _coOpUIHolder;
    [SerializeField] private GameObject _highScoreUIHolder;

    //holding data for single player
    [SerializeField] private TextMeshProUGUI _currentSinglePlayerName;
    [SerializeField] private TextMeshProUGUI _bestPlayerName;
    [SerializeField] private TextMeshProUGUI _bestPlayerScore;

    //holding data for co-op players
    [SerializeField] private TextMeshProUGUI _currentPlayer1Name;
    [SerializeField] private TextMeshProUGUI _currentPlayer2Name;
    [SerializeField] private TextMeshProUGUI _player1Name;
    [SerializeField] private TextMeshProUGUI _player1Score;
    [SerializeField] private TextMeshProUGUI _player2Name;
    [SerializeField] private TextMeshProUGUI _player2Score;

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

        _player1Name.text = $"Player 1:   {ScoreManager.Instance.player1Name}";
        _player1Score.text = $"Score:   {ScoreManager.Instance.player1Score}";
        _player2Name.text = $"Player 2:   {ScoreManager.Instance.player2Name}";
        _player2Score.text = $"Score:   {ScoreManager.Instance.player2Score}";

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

        ScoreManager.Instance.currentSinglePlayerName = _currentSinglePlayerName.text;
        SceneManager.LoadScene(1);
    }

    private void OpenCoOpGameScene()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);

        ScoreManager.Instance.currentPlayer1Name = _currentPlayer1Name.text;
        ScoreManager.Instance.currentPlayer2Name = _currentPlayer2Name.text;
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
