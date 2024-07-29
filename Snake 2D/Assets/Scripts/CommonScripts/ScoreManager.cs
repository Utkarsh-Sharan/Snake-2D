using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour   //will handle player data (name and score)
{
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }

    //current player data
    [HideInInspector] public string currentPlayerName;
    [HideInInspector] public int currentPlayerScore;

    //best player data
    [HideInInspector] public string bestPlayerName;
    [HideInInspector] public int bestPlayerScore;

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
    public class SaveData
    {
        public string bestPlayerName;
        public int bestPlayerScore;
    }

    /*************** Using JSON for saving and loading player data ***************/
    public void SaveBestPlayerData(string bestPlayerName, int bestPlayerScore)
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestPlayerScore = bestPlayerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadBestPlayerData()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestPlayerScore = data.bestPlayerScore;
        }
    }
}
