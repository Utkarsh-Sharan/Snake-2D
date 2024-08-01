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

            //case GameType.CO_OP:      //will define later
        }
    }

    private void CheckForBestSinglePlayer()
    {
        int score = ScoreManager.Instance.currentPlayer1Score;
        if (score > ScoreManager.Instance.bestPlayerScore)
        {
            ScoreManager.Instance.bestPlayerScore = score;
            ScoreManager.Instance.bestPlayerName = ScoreManager.Instance.currentPlayer1Name;

            ScoreManager.Instance.SaveBestPlayerData(ScoreManager.Instance.bestPlayerName, score);
        }
    }
}

public enum GameType
{
    SINGLE_PLAYER,
    CO_OP
}
