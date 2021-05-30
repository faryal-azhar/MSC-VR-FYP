using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using Core;

namespace SpellingActivity
{
    [RequireComponent(typeof(Celebrator))]
    public class SpellingManager : MonoBehaviour,IAction
    {
        public bool IsActive => isActive;
        bool isActive = false;
        [SerializeField] SpellingUiManager uiManager;
        [SerializeField] ActivityScheduler activityScheduler;
        [SerializeField] HighScoreManager highScoreManager;
        [Header("Modes File Name")]
        [SerializeField] string easyModeFile = "easy.txt";
        [SerializeField] string mediumModeFile = "medium.txt";
        [SerializeField] string hardModeFile = "hard.txt";

        [Header("Modes Score")]
        [SerializeField] int easyScore = 5;
        [SerializeField] int mediumScore = 10;
        [SerializeField] int hardScore = 15;
        public string modePath => Path.Combine(Application.dataPath, folderName, modeFileName);
        public string dictionaryPath => Path.Combine(Application.dataPath, folderName, dictionaryFileName);

        string modeFileName="";
        string dictionaryFileName => "condenseDictionary.txt";

        protected List<string> words = new List<string>();
        protected string[] dictionaryWords;
        
        

        const string folderName = "TextDataFiles";

        string currentWord;
        string scrambledWord="";

        public static event Action<string> GenerateBalloon;
        public static event Action DestroyBalloon;

        int scorePerCorrectGuess;
        int totalScore;
        int highScore;

        [Header("Audio Clips")]
        [SerializeField] AudioClip background;
        [SerializeField] AudioClip correctWord;
        [SerializeField] AudioClip wrongWord;

        AudioSource audioSource;


        private void Awake()
        {
            dictionaryWords = File.ReadAllLines(dictionaryPath);
            audioSource = GetComponent<AudioSource>();
            
        }

        public void SelectMode(int num)
        {
            switch (num)
            {
                case 1:
                    modeFileName = easyModeFile;
                    scorePerCorrectGuess = easyScore;
                    break;
                case 2:
                    modeFileName = mediumModeFile;
                    scorePerCorrectGuess = mediumScore;
                    break;
                case 3:
                    modeFileName = hardModeFile;
                    scorePerCorrectGuess = hardScore;
                    break;
            }
            words = File.ReadAllLines(modePath).ToList();
        }

        private void OnDisable()
        {          
            QuitActivity();
        }

        public void QuitActivity()
        {
            if (!isActive) return;
            isActive = false;
            BalloonGenerator.CheckTheWord -= BalloonGenerator_CheckTheWord;
            if (DestroyBalloon != null) DestroyBalloon();
            modeFileName = "";
            CheckForHighScore();
            uiManager.UpdateScore("");
            uiManager.EmptyResult();
            uiManager.EmptyScrabledWord();
        }

        private void OnEnable()
        {
            isActive = true;
            BalloonGenerator.CheckTheWord += BalloonGenerator_CheckTheWord;
            totalScore = 0;         
        }

        public void StartActivity()
        {
            activityScheduler.StartAction(this,background);
            isActive = true;
            if (modeFileName == "")
            {
                modeFileName = easyModeFile;
                scorePerCorrectGuess = easyScore;
                words = File.ReadAllLines(modePath).ToList();
            }      
            GenerateTheWord();
        }

        private void BalloonGenerator_CheckTheWord(string guessedWord)
        {
            if (!enabled) return;
            if (dictionaryWords.Contains(guessedWord.ToLower()))
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
            audioSource.PlayOneShot(correctWord);
            totalScore += scorePerCorrectGuess;
            uiManager.UpdateScore(totalScore.ToString());
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
                highScoreManager.SetSpellingHighScores(highScore);
            }
        }

        IEnumerator IncorrectGuess () //with same word (in the case of incorrect guess)
        {
            Debug.Log("Incorrect");
            uiManager.InCorrect();
            audioSource.PlayOneShot(wrongWord);
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
