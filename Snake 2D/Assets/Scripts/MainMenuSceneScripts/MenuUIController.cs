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
    //[SerializeField] private GameObject _coOpUIHolder;
    [SerializeField] private GameObject _highScoreUIHolder;

    [SerializeField] private TextMeshProUGUI _currentPlayerName;
    [SerializeField] private TextMeshProUGUI _bestPlayerName;
    [SerializeField] private TextMeshProUGUI _bestPlayerScore;

    [SerializeField] private Button _singlePlayerPlayButton;
    [SerializeField] private Button _coOpPlayButton;
    [SerializeField] private Button _highScoreButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _quitButton;

    // Start is called before the first frame update
    void Start()
    {
        _singlePlayerPlayButton.onClick.AddListener(OpenSinglePlayerNameInputField);
        _coOpPlayButton.onClick.AddListener(OpenCoOpPlayersNameInputField);
        _highScoreButton.onClick.AddListener(OpenHighScore);
        _playButton.onClick.AddListener(OpenGameScene);
        _backToMenuButton.onClick.AddListener(CloseHighScore);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OpenSinglePlayerNameInputField()
    {
        GameManager.Instance.GameType = GameType.SINGLE_PLAYER;

        _menuUIHolder.SetActive(false);
        _singlePlayerUIHolder.SetActive(true);
    }

    private void OpenCoOpPlayersNameInputField()
    {
        //will add logic later
    }

    private void OpenHighScore()
    {
        ScoreManager.Instance.LoadBestPlayerData();
        _bestPlayerName.text = $"Best Player: {ScoreManager.Instance.bestPlayerName}";
        _bestPlayerScore.text = $"Score: {ScoreManager.Instance.bestPlayerScore}";

        _menuUIHolder.SetActive(false);
        _highScoreUIHolder.SetActive(true);
    }

    private void CloseHighScore()
    {
        _highScoreUIHolder.SetActive(false);
        _menuUIHolder.SetActive(true);
    }

    private void OpenGameScene()
    {
        ScoreManager.Instance.currentPlayerName = _currentPlayerName.text;
        SceneManager.LoadScene(1);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
