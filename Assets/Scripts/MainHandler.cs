
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainHandler : MonoBehaviour
{
    public static MainHandler Instance;
    public string playerName;
    public int highscore;
    public string temporaryName;

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highscore;
    }
    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highscore = highscore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highscore = data.highscore;
        }
    }
}
