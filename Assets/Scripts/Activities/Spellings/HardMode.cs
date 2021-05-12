using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpellingActivity
{
    public class HardMode : Modes
    {
        public override string modeFileName => "hard.txt";

        public override string dictionaryFileName => "condenseDictionary.txt";

        private void Start()
        {
            Debug.Log("Hard Mode");
            GenerateTheWord();
        }

        public override void GenerateTheWord()
        {
            base.GenerateTheWord();
        }
    }
}
