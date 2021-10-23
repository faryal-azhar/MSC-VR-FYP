using UnityEngine;

namespace KidsVR.HighScores
{
    public class HighScoreManager : MonoBehaviour
    {
        private HighScoreRepository repository;

        private void Awake()
        {
            repository = new HighScoreRepository();
        }

        public int GetHighScore(HighScoreCategory category)
        {
            return repository.Get(category);
        }

        public void SubmitScore(HighScoreCategory category, int score)
        {
            repository.TrySubmit(category, score);
        }
    }
}
