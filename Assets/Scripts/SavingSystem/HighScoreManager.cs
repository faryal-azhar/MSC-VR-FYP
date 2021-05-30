using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager:MonoBehaviour
{
    // spellingActivity;        //key 1
    // basketballAddition;      //key 2
    // basketballSubtraction;   //key 3
    // basketbalMultiplication; //key 4
    // basketbalDivision;       //key 5

    SavingSystem savingSystem;
    Dictionary<int,int> highScores;

    private void Awake()
    {
        savingSystem = GetComponent<SavingSystem>();
        highScores=savingSystem.LoadFile();
        CheckTheDictionary();
    }

    void CheckTheDictionary()
    {
        for(int i = 1; i < 6; i++)
        {
            if (!highScores.ContainsKey(i))
            {
                highScores.Add(i, 0);
            }
        }
        Debug.Log(highScores[2]);
    }

    public void SetSpellingHighScores(int hScore)
    {
        if (highScores.ContainsKey(1))
        {
            if (highScores[1] < hScore)
            {
                highScores[1] = hScore;
                savingSystem.SaveFile();
            }             
        }   
    }
    public void SetBasketballAdditionHighScores(int hScore)
    {
        
        if (highScores.ContainsKey(2))
        {
            if(highScores[2] < hScore)
            {
                highScores[2] = hScore;
                Debug.Log("Called Addition");
                savingSystem.SaveFile();
            }             
        }
    }
    public void SetBasketballSubtractionHighScores(int hScore)
    {
        if (highScores.ContainsKey(3))
        {
            if(highScores[3] < hScore)
            {
                highScores[3] = hScore;
                savingSystem.SaveFile();
            }             
        }     
    }
    public void SetBasketbalMultiplicationHighScores(int hScore)
    {
        if (highScores.ContainsKey(4))
        {
            if(highScores[4] < hScore)
            {
                highScores[4] = hScore;
                savingSystem.SaveFile();
            }              
        }   
    }
    public void SetBasketbalDivisionHighScores(int hScore)
    {
        if (highScores.ContainsKey(5))
        {
            if(highScores[5] < hScore)
            {
                highScores[5] = hScore;
                savingSystem.SaveFile();
            }             
        }
    }

    public Dictionary<int, int> GetHighScores()
    {
        return highScores;
    }


}
