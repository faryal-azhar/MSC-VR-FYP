using System;
using UnityEngine;

namespace KidsVR.Activities.Spelling
{
    public enum SpellingDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    [Serializable]
    public class SpellingLevel
    {
        public TextAsset wordList;
        public int pointsPerWord;
    }
}
