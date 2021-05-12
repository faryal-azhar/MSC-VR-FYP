using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ReadFromFile : MonoBehaviour
{
    [SerializeField] Text text;
    string path;
    string dicPath;
    string fileName = "easy.txt";
    string folderName = "TextDataFiles";
    string dictionary = "engDict.txt";

    List<string> words = new List<string>();

    bool exist = false;
    int count = 0;

    string[] lines;
    string[] dicLines;

    List<string> newWords=new List<string>();

    string word;

    private void Start()
    {
        path = Path.Combine(Application.dataPath, folderName, fileName);
        dicPath = Path.Combine(Application.dataPath, folderName, dictionary);
        lines = File.ReadAllLines(path);
        dicLines = File.ReadAllLines(dicPath);
        
        //CheckForWordInDic();
        int count = 0;
        foreach(string l in dicLines)
        {
            if (l.Length > 2 && l.Length < 6)
            {
                newWords.Add(l);
                count++;
            }
        }
        Debug.Log(count + "  " + newWords.Count);

    }



    private void CheckForWordInDic()
    {
        foreach (string line in lines)
        {
            exist = false;
            foreach (string l in dicLines)
            {
                if (line == l)
                {
                    count++;
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                words.Add(line);
            }
        }

        foreach (string l in words)
        {
            Debug.Log(l);
        }

        word = lines[Random.Range(0, lines.Length)];

        text.text = word;

        Debug.Log(count);
    }
}
