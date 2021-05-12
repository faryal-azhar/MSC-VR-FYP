using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SpellingActivity
{
    public class EasyMode : Modes
    {
        public override string modeFileName => "easy.txt"; 
        public override string dictionaryFileName => "condenseDictionary.txt";




        private void Start()
        {
            Debug.Log("Easy Mode");
            GenerateTheWord();
        }
        public override void GenerateTheWord()
        {
            base.GenerateTheWord();
        }
    }
}
