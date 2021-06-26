using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    //Declare Instance
    public static DataManager Instance;

    //Variables to Share
    public string playerName;

    public int currentHighScore;

    public string topPlayer;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadInfo();
    }

    //JSON Support
    [System.Serializable]
    class SaveData
    {
        //Variables to be saved
        public string playerName;
        public int currentHighScore;
        public string topPlayer;
    }

    public void SaveInfo()
    {
        //Create Instance of Save Data and fill with saved variables
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.currentHighScore = currentHighScore;
        data.topPlayer = topPlayer;

        //Transform Instance into JSON
        string json = JsonUtility.ToJson(data);

        //Write string path to file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        //Reversal of SaveInfo method
        string path = Application.persistentDataPath + "/savefile.json";

        //If .json file exists, read it
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            //Give retulding text to JsonUtility.FromJson to transform it back into a SaveData Instance
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //Set variables
            playerName = data.playerName;
            currentHighScore = data.currentHighScore;
            topPlayer = data.topPlayer;
        }
    }
}
