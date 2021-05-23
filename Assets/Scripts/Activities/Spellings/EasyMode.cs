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


    }
}
