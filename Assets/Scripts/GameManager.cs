using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public string playerName = "";
    public int bestScore = 0;
    public string bestPlayerName;
    static public GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance)
        {
            Destroy(gameObject);
        }else {
            instance = this;
            if(File.Exists("./bestPlayer.json"))
            {
                LoadInfo();
            }
            DontDestroyOnLoad(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBestScore(int score) {
        bestScore = score;
        SaveInfo();
    }


    public void SetPlayerName(string name) {
        playerName = name;
    }

    [System.Serializable]
    class SessionInfo 
    {
        public string name;
        public int bestScore;
    }

    void SaveInfo()
    {
        SessionInfo si = new SessionInfo();
        si.name = playerName;
        si.bestScore = bestScore;

        string jsonStr = JsonUtility.ToJson(si);
        File.WriteAllText("./bestPlayer.json", jsonStr);
    }

    void LoadInfo()
    {
        string json = File.ReadAllText("./bestPlayer.json");
        SessionInfo si = JsonUtility.FromJson<SessionInfo>(json);
        bestPlayerName = si.name;
        bestScore = si.bestScore;
    }
}
