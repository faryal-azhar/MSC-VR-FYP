using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    HighScoreManager highScoreManager;
    string fileName = "save";

    private void Awake()
    {
        highScoreManager = GetComponent<HighScoreManager>();
    }

    public void SaveFile()
    {
        Debug.Log("Called Save file : " + GetPathOfFile());
        using (FileStream fileStream = File.Open(GetPathOfFile(), FileMode.Create))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, highScoreManager.GetHighScores());
        }
    }

    public Dictionary<int,int> LoadFile()
    {
        Debug.Log("Called Load File: " + GetPathOfFile());
        if(!File.Exists(GetPathOfFile())) return new Dictionary<int, int>();
        using (FileStream fileStream = File.Open(GetPathOfFile(), FileMode.Open))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (Dictionary<int, int>) binaryFormatter.Deserialize(fileStream);
        }
    }


    public string GetPathOfFile()
    {
        return Path.Combine(Application.persistentDataPath, fileName + ".sav");
    }
}
