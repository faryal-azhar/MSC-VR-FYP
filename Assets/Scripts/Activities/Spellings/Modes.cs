using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpellingActivity
{
    public abstract class Modes : MonoBehaviour
    {
        [SerializeField] SpellingUiManager uiManager;
        

        public string modePath => Path.Combine(Application.dataPath, folderName, modeFileName);
        public string dictionaryPath => Path.Combine(Application.dataPath, folderName, dictionaryFileName);

        public abstract string modeFileName { get; }
        public abstract string dictionaryFileName { get; }

        protected List<string> words = new List<string>();
        protected string[] dictionaryWords;
        
        

        public static string folderName = "TextDataFiles";

        protected string currentWord;
        protected string scrambledWord="";

        public static event Action<string> GenerateBalloon;
        public static event Action DestroyBalloon;

        public int scorePerCorrectGuess;
        public int totalScore;
        public int highScore;

        private void Awake()
        {
            words = File.ReadAllLines(modePath).ToList();
            dictionaryWords = File.ReadAllLines(dictionaryPath);

            BalloonGenerator.CheckTheWord += BalloonGenerator_CheckTheWord;
        }

        private void OnDisable()
        {
            BalloonGenerator.CheckTheWord -= BalloonGenerator_CheckTheWord;
            if (DestroyBalloon != null) DestroyBalloon();
            CheckForHighScore();

        }

        private void OnEnable()
        {
            totalScore = 0;
            GenerateTheWord();
        }

        private void BalloonGenerator_CheckTheWord(string guessedWord)
        {
            if (!enabled) return;
            if (dictionaryWords.Contains(guessedWord))
            {
                GetComponent<Celebrator>().Celebration();
                StartCoroutine("CorrectGuess") ;  
            }
            else
            {
                StartCoroutine("IncorrectGuess");
            }
            
        }

        IEnumerator CorrectGuess()
        {
            Debug.Log("Correct");
            uiManager.Correct();
            totalScore += scorePerCorrectGuess;
            uiManager.UpdateScore(totalScore);
            CheckForHighScore();
            yield return new WaitForSeconds(3);
            uiManager.EmptyResult();
            uiManager.EmptyUnScrambledWord();
            GenerateTheWord();
        }

        void CheckForHighScore()
        {
            if (totalScore > highScore)
            {
                highScore = totalScore;
            }
        }

        IEnumerator IncorrectGuess () //with same word (in the case of incorrect guess)
        {
            Debug.Log("Incorrect");
            uiManager.InCorrect();
            yield return new WaitForSeconds(3);
            uiManager.EmptyUnScrambledWord();
            uiManager.EmptyResult();
            GenerateBalloon(scrambledWord);
        }

        public virtual void GenerateTheWord()
        {
            Debug.Log(name + "  : " + words.Count);
            currentWord = words[UnityEngine.Random.Range(0, words.Count)];
            ScrambleTheWord();
            //scrambledWordText.text = scrambledWord;
            uiManager.UpdateScrabledWord(scrambledWord);
            Debug.Log(currentWord + " ,,,, " + scrambledWord);
            if (GenerateBalloon != null)
            {
                GenerateBalloon(scrambledWord);
            }
            else
            {
                Debug.Log("Action is null");
            }
        }

        private void ScrambleTheWord()
        {
            scrambledWord="";
            List<char> characters = new List<char>();
            foreach(char w in currentWord)
            {
                characters.Add(w);
            }
            while (characters.Count > 0)
            {
                char randomCharacter = characters[UnityEngine.Random.Range(0, characters.Count)];
                scrambledWord += randomCharacter;
                characters.Remove(randomCharacter);
            }

            if (scrambledWord == currentWord) ScrambleTheWord();
            
        }
    }
}
