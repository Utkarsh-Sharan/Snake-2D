using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour   //will handle player data (name and score)
{
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }

    //current player data
    [HideInInspector] public string currentPlayer1Name;
    [HideInInspector] public int currentPlayer1Score;

    [HideInInspector] public string currentPlayer2Name;
    [HideInInspector] public int currentPlayer2Score;

    //best single player data
    [HideInInspector] public string bestPlayerName;
    [HideInInspector] public int bestPlayerScore;

    //co-op players data
    [HideInInspector] public string player1Name;
    [HideInInspector] public int player1Score;

    [HideInInspector] public string player2Name;
    [HideInInspector] public int player2Score;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [System.Serializable]
    public class SaveBestSinglePlayerData
    {
        public string bestPlayerName;
        public int bestPlayerScore;
    }

    [System.Serializable]
    public class SaveCoOpPlayerData
    {
        public string player1Name;
        public int player1Score;

        public string player2Name;
        public int player2Score;
    }

    /*************** Using JSON for saving and loading player data ***************/
    public void SaveBestPlayerData(string bestPlayerName, int bestPlayerScore)
    {
        SaveBestSinglePlayerData data = new SaveBestSinglePlayerData();
        data.bestPlayerName = bestPlayerName;
        data.bestPlayerScore = bestPlayerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void SaveCoOpPlayersData(string player1Name, int player1Score, string player2Name, int player2Score)
    {
        SaveCoOpPlayerData data = new SaveCoOpPlayerData();
        data.player1Name = player1Name;
        data.player1Score = player1Score;

        data.player2Name = player2Name;
        data.player2Score = player2Score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            //getting single player data from save file
            SaveBestSinglePlayerData data1 = JsonUtility.FromJson<SaveBestSinglePlayerData>(json);
            bestPlayerName = data1.bestPlayerName;
            bestPlayerScore = data1.bestPlayerScore;

            //getting co-op players data from load file
            SaveCoOpPlayerData data2 = JsonUtility.FromJson<SaveCoOpPlayerData>(json);
            player1Name = data2.player1Name;
            player1Score = data2.player1Score;
            player2Name = data2.player2Name;
            player2Score = data2.player2Score;
        }
    }
}
