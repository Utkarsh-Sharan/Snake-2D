using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestPlayerName;
    [SerializeField] private TextMeshProUGUI _bestPlayerScore;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _quitButton;

    private void Start()
    {
        _bestPlayerName.text = $"Best Player: {ScoreManager.Instance.bestPlayerName}";
        _bestPlayerScore.text = $"Score: {ScoreManager.Instance.bestPlayerScore}";
        _mainMenuButton.onClick.AddListener(MainMenuButton);
        _quitButton.onClick.AddListener(QuitToDesktopButton);
    }

    private void MainMenuButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    private void QuitToDesktopButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
