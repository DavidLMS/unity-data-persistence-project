using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    public static int BestScore;
    public static string BestPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestPlayer;
    }

    public void SaveScore()
    {
        if (MainManager.m_Points > BestScore)
        {
            SaveData data = new SaveData();
            data.BestScore = MainManager.m_Points;
            data.BestPlayer = MenuUIHandler.playerName;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        }
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestPlayer = data.BestPlayer;
        }
        else {
            BestScore = 0;
            BestPlayer = "";
        }
    }
}
