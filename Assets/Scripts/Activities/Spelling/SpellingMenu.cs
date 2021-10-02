using UnityEngine;

namespace KidsVR.Activities.Spelling
{
    // Called from the buttons on the spelling board.
    public class SpellingMenu : MonoBehaviour
    {
        [SerializeField] private SpellingActivity activity;

        public void SelectEasy()
        {
            SelectDifficulty(SpellingDifficulty.Easy);
        }

        public void SelectMedium()
        {
            SelectDifficulty(SpellingDifficulty.Medium);
        }

        public void SelectHard()
        {
            SelectDifficulty(SpellingDifficulty.Hard);
        }

        public void StartGame()
        {
            activity.StartActivity();
        }

        public void StopGame()
        {
            activity.StopActivity();
        }

        private void SelectDifficulty(SpellingDifficulty difficulty)
        {
            activity.StopActivity();
            activity.SetDifficulty(difficulty);
        }
    }
}
