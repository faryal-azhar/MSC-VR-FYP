using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUpdater : MonoBehaviour
{
    [Header("Activities highScore Text")]
    [SerializeField] TextMeshProUGUI spelling;
    [SerializeField] TextMeshProUGUI addition;
    [SerializeField] TextMeshProUGUI subtraction;
    [SerializeField] TextMeshProUGUI multiplication;
    [SerializeField] TextMeshProUGUI division;

    Dictionary<int, int> highScores => GetComponent<SavingSystem>().LoadFile();

    private void Start()
    {
        spelling.text = highScores[1].ToString();
        addition.text = highScores[2].ToString();
        subtraction.text = highScores[3].ToString();
        multiplication.text = highScores[4].ToString();
        division.text = highScores[5].ToString();
    }


}
