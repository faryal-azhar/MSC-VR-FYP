using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class DictionaryCreater : MonoBehaviour
{
    string dictionaryPath;
    string modePatth;
    string newDicPath;
    string mediumMode;
    string hardMode;

    readonly string fileName = "easy.txt";
    readonly string mediumName = "medium.txt";
    readonly string folderName = "TextDataFiles";
    //sreadonly string dictionary = "engDict.txt";
    readonly string newdict = "condenseDictionary.txt";
    readonly string hardModeName = "hard.txt";

    string[] modeWords;
    string[] mediumWords;
    string[] dictWords;
    string[] lessWords;

    string[] hardModeWords;

    //string checkWord="but";
    List<string> wordsToAdd=new List<string>();

    private void Start()
    {
        //dictionaryPath = Path.Combine(Application.dataPath, folderName, dictionary);
        modePatth = Path.Combine(Application.dataPath, folderName, fileName);
        newDicPath = Path.Combine(Application.dataPath, folderName, newdict);
        mediumMode = Path.Combine(Application.dataPath, folderName, mediumName);
        hardMode = Path.Combine(Application.dataPath, folderName, hardModeName);

        dictWords = File.ReadAllLines(newDicPath);
        modeWords = File.ReadAllLines(modePatth);
        mediumWords = File.ReadAllLines(mediumMode);
        hardModeWords = File.ReadAllLines(hardMode);

        //newMediumWord = mediumWords;
        //StarRemover();
        //hardModeWords = hardModeWords.Where(word => word.Length < 7).ToArray();
        //mediumWords = mediumWords.Where(word => word.Length < 7).ToArray();
        // mediumWords = mediumWords.Where(word => word.Length > 2).ToArray();

        //mediumWords=mediumWords.Distinct().ToArray();
        //hardModeWords=hardModeWords.Distinct().ToArray();

        hardModeWords=hardModeWords.OrderByDescending(w => w).Reverse().ToArray();

        File.WriteAllLines(hardMode,hardModeWords);
        //File.WriteAllLines(mediumMode,mediumWords);
        foreach (string w in mediumWords)
        {
            if (!dictWords.Contains(w))
            {
                Debug.Log(w);
            }
        }



    }

    private void RangeCreater()
    {
        lessWords = dictWords.Where(word => word.Length > 2 && word.Length < 7).ToArray();
        File.WriteAllLines(newDicPath, lessWords);
    }

    private void StarRemover()
    {
        for(int i=0;i<hardModeWords.Length;i++)
        {
            if (hardModeWords[i].Contains("*"))
            {
                for(int j = 0; j < hardModeWords[i].Length; j++)
                {
                    if (hardModeWords[i][j] == '*')
                    {
                        hardModeWords[i] = hardModeWords[i].Remove(j);
                    }
                }
            }
        }
    }
}
