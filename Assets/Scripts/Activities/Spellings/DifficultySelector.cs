using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace SpellingActivity
{
    public class DifficultySelector : MonoBehaviour
    {
        // 1-easy , 2-medium , 3-hard
        public SpellingManager spellingManager;
        public BalloonGenerator balloonGenerator;

        public void PressEasy()
        {
            if (spellingManager.IsActive) QuitModes();
            spellingManager.SelectMode(1);
        }

        public void PressMedium()
        {
            if (spellingManager.IsActive) QuitModes();
            spellingManager.SelectMode(2);
        }

        public void PressHard()
        {
            if (spellingManager.IsActive) QuitModes();
            spellingManager.SelectMode(3);
        }

        public void QuitModes()
        {
            spellingManager.QuitActivity();
            spellingManager.enabled = false;
            balloonGenerator.enabled = false;          
        }

        public void StartMode()
        {
            spellingManager.enabled = true;
            balloonGenerator.enabled = true;
            spellingManager.StartActivity();
        }
    }
   
}
