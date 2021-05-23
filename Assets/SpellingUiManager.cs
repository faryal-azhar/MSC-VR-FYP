using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpellingActivity
{
    public class SpellingUiManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scrambledWord;
        [SerializeField] TextMeshProUGUI unScrambledWord;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] TextMeshProUGUI result;

        public void UpdateScrabledWord(string word)
        {
            scrambledWord.text = word;
        }
        public void UpdateUnScrabledWord(string ch)
        {
            unScrambledWord.text = ch;
        }
        public void EmptyUnScrambledWord()
        {
            unScrambledWord.text = "";
        }
        public void Correct()
        {
            result.text = "Yayyy!!";
        }

        public void InCorrect()
        {
            result.text = "Oops, Try Again.";
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void EmptyResult()
        {
            result.text = "";
        }
    }

}