using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellingActivity
{
    public class MediumMode : Modes
    {
        public override string modeFileName => "medium.txt";

        public override string dictionaryFileName => "condenseDictionary.txt";

        private void Start()
        {
            Debug.Log("Medium Mode");
            GenerateTheWord();
        }

        public override void GenerateTheWord()
        {
            base.GenerateTheWord();
        }
    }
}
