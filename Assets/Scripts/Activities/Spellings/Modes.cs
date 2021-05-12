using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SpellingActivity
{
    public abstract class Modes : MonoBehaviour
    {
        [SerializeField] Text scrambledWordText;

        public string modePath => Path.Combine(Application.dataPath, folderName, modeFileName);
        public string dictionaryPath => Path.Combine(Application.dataPath, folderName, dictionaryFileName);

        public abstract string modeFileName { get; }
        public abstract string dictionaryFileName { get; }

        protected List<string> words = new List<string>();
        
        

        public static string folderName = "TextDataFiles";

        protected string currentWord;
        protected string scrambledWord="";

        public static event Action<string> GenerateBalloon;

        private void Awake()
        {
            words = File.ReadAllLines(modePath).ToList();
        }

        public virtual void GenerateTheWord()
        {
            currentWord = words[UnityEngine.Random.Range(0, words.Count)];
            ScrambleTheWord();
            scrambledWordText.text = scrambledWord;
            Debug.Log(currentWord + "  " + scrambledWord);
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
