using System;
using UnityEngine;

namespace KidsVR.Activities.Basketball
{
    public class BasketballDifficulty : MonoBehaviour
    {
        [Serializable]
        private struct Level
        {
            public int minNumber;
            public int maxNumber;
            public int pointsPerGoal;

            public Level(int minNumber, int maxNumber, int pointsPerGoal)
            {
                this.minNumber = minNumber;
                this.maxNumber = maxNumber;
                this.pointsPerGoal = pointsPerGoal;
            }
        }

        [SerializeField] private BasketballActivity activity;
        [SerializeField] private Level easy = new Level(1, 11, 5);
        [SerializeField] private Level medium = new Level(11, 21, 10);
        [SerializeField] private Level hard = new Level(21, 31, 15);

        public void SelectEasy()
        {
            Apply(easy);
        }

        public void SelectMedium()
        {
            Apply(medium);
        }

        public void SelectHard()
        {
            Apply(hard);
        }

        private void Apply(Level level)
        {
            activity.SetNumberRange(level.minNumber, level.maxNumber);
            activity.Score.SetPointsPerGoal(level.pointsPerGoal);
        }
    }
}
