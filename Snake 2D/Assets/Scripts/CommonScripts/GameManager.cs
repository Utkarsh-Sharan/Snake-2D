using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private GameType _gameType;
    public GameType GameType { get { return _gameType; } set { _gameType = value; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GameOverHandler(GameObject gameOverUIPanel)
    {
        switch (_gameType)
        {
            case GameType.SINGLE_PLAYER:
                CheckForBestSinglePlayer();
                ScoreManager.Instance.LoadPlayerData();
                gameOverUIPanel.SetActive(true);
                Time.timeScale = 0f;
                break;

            case GameType.CO_OP:
                SaveCoOpPlayers();
                gameOverUIPanel.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }

    private void CheckForBestSinglePlayer()
    {
        int score = ScoreManager.Instance.currentSinglePlayerScore;
        if (score > ScoreManager.Instance.bestPlayerScore)
        {
            ScoreManager.Instance.bestPlayerScore = score;
            ScoreManager.Instance.bestPlayerName = ScoreManager.Instance.currentSinglePlayerName;

            ScoreManager.Instance.SaveBestPlayerData(ScoreManager.Instance.bestPlayerName, score);
        }
    }

    private void SaveCoOpPlayers()
    {
        string player1Name = ScoreManager.Instance.currentPlayer1Name;
        int player1Score = ScoreManager.Instance.currentPlayer1Score;

        string player2Name = ScoreManager.Instance.currentPlayer2Name;
        int player2Score = ScoreManager.Instance.currentPlayer2Score;

        ScoreManager.Instance.SaveCoOpPlayersData(player1Name, player1Score, player2Name, player2Score);
    }
}

public enum GameType
{
    SINGLE_PLAYER,
    CO_OP
}
