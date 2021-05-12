using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellingActivity
{
    public class CustomMode : Modes
    {
        public override string modeFileName => throw new System.NotImplementedException();

        public override string dictionaryFileName => throw new System.NotImplementedException();


        private void Start()
        {
            Debug.Log("Custom Mode");
        }
    }
}
