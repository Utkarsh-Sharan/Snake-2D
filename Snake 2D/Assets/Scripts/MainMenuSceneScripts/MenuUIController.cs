using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _uiObjectList = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI _currentPlayerName;
    //[SerializeField] private TextMeshProUGUI _bestPlayerName;
    //[SerializeField] private TextMeshProUGUI _bestPlayerScore;

    [SerializeField] private Button _singlePlayerPlayButton;
    [SerializeField] private Button _playButton;

    // Start is called before the first frame update
    void Start()
    {
        _singlePlayerPlayButton.onClick.AddListener(OpenPlayerNameInputField);
        _playButton.onClick.AddListener(OpenGameScene);
    }

    private void OpenPlayerNameInputField()
    {
        GameManager.Instance.GameType = GameType.SINGLE_PLAYER;

        for (int i = 0; i < _uiObjectList.Count; i++)
        {
            if (i == 0)
            {
                _uiObjectList[0].SetActive(false);
            }
            else
            {
                _uiObjectList[i].SetActive(true);
            }
        }
    }

    private void OpenGameScene()
    {
        ScoreManager.Instance.currentPlayerName = _currentPlayerName.text;
        SceneManager.LoadScene(1);
    }
}
