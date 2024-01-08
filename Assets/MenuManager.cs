using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public string Name;
    public int score;

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            score = 0;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    [System.Serializable]
    class SaveData
    {
        public int Score;
        public string Name;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Score = score;    
        data.Name = Name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.Score;
            Name = data.Name;
        }
    }
}
