using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentPlayer1Name;
    [SerializeField] private TextMeshProUGUI _currentPlayer2Name;
    [SerializeField] private TextMeshProUGUI _player1ScoreText;
    [SerializeField] private TextMeshProUGUI _player2ScoreText;
    [SerializeField] private GameObject _gameOverUIPanel;

    private int _player1Score = 0;
    private int _player2Score = 0;

    private void Start()
    {
        if(GameManager.Instance.GameType == GameType.SINGLE_PLAYER)
        {
            _currentPlayer1Name.text = $"Player : {ScoreManager.Instance.currentSinglePlayerName}";
            _player1ScoreText.text = "Score: " + _player1Score;
        }
        else
        {
            _currentPlayer1Name.text = $"Player : {ScoreManager.Instance.currentPlayer1Name}";
            _player1ScoreText.text = "Score: " + _player1Score;

            _currentPlayer2Name.text = $"Player : {ScoreManager.Instance.currentPlayer2Name}";
            _player2ScoreText.text = "Score: " + _player2Score;
        }
    }

    public void Player1ScoreController(int score)
    {
        _player1Score += score;

        if(_player1Score < 0)
        {
            _player1Score = 0;                                           //so that score can't go negative
            GameManager.Instance.GameOverHandler(_gameOverUIPanel);     //end the game 
        }

        if(GameManager.Instance.GameType == GameType.SINGLE_PLAYER)
        {
            ScoreManager.Instance.currentSinglePlayerScore = _player1Score;
        }
        else
        {
            ScoreManager.Instance.currentPlayer1Score = _player1Score;
        }
        
        _player1ScoreText.text = "Score: " + _player1Score;
    }

    public void Player2ScoreController(int score)
    {
        _player2Score += score;

        if (_player2Score < 0)
        {
            _player2Score = 0;                                           //so that score can't go negative
            GameManager.Instance.GameOverHandler(_gameOverUIPanel);     //end the game 
        }

        ScoreManager.Instance.currentPlayer2Score = _player2Score;
        _player2ScoreText.text = "Score: " + _player2Score;
    }
}
