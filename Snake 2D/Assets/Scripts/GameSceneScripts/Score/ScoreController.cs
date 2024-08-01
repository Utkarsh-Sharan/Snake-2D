using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentPlayerName;
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private GameObject _gameOverUIPanel;

    private int _playerScore = 0;

    private void Start()
    {
        _currentPlayerName.text = $"Player : {ScoreManager.Instance.currentSinglePlayerName}";
        _playerScoreText.text = "Score: " + _playerScore;
    }

    public void PlayerScoreController(int score)
    {
        _playerScore += score;

        if(_playerScore < 0)
        {
            _playerScore = 0;                                           //so that score can't go negative
            GameManager.Instance.GameOverHandler(_gameOverUIPanel);     //end the game 
        }

        ScoreManager.Instance.currentSinglePlayerScore = _playerScore;
        _playerScoreText.text = "Score: " + _playerScore;
    }
}
