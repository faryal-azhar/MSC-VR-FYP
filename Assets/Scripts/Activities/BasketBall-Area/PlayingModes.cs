using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBallActivity
{
    public class PlayingModes : MonoBehaviour
    {
        [SerializeField] BasketBallManager basketBallManager;
        BasketBallScores basketBallScores;

        private void Start()
        {
            basketBallScores = basketBallManager.GetComponent<BasketBallScores>();
            
        }

        public void EasyMode()
        {
                basketBallManager.SetMinMaxRange(1, 11);
                basketBallScores.SetScoresPerGoal(5);
        }

        public void IntermediateMode()
        {   
 
                basketBallManager.SetMinMaxRange(11, 21);
                basketBallScores.SetScoresPerGoal(10);
            
        }

        public void HardMode()
        {
                basketBallManager.SetMinMaxRange(21, 31);
                basketBallScores.SetScoresPerGoal(15);

        }

    }
}
