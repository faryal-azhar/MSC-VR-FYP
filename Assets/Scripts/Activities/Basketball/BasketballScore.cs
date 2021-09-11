using System;
using KidsVR.HighScores;
using TMPro;
using UnityEngine;

namespace KidsVR.Activities.Basketball
{
    public class BasketballScore : MonoBehaviour
    {
        [SerializeField] private HighScoreManager highScoreManager;
        [SerializeField] private int pointsPerGoal = 5;
        [SerializeField] private int startingChances = 5;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI chancesText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private HighScoreCategory category;
        private int score;
        private int chancesLeft;

        public event Action OutOfChances;

        public void Initialize(HighScoreCategory scoreCategory)
        {
            category = scoreCategory;
            ResetScore();
            UpdateHighScoreText();
        }

        public void SetPointsPerGoal(int points)
        {
            pointsPerGoal = points;
        }

        public void AddGoal()
        {
            score += pointsPerGoal;
            UpdateTexts();
        }

        public void LoseChance()
        {
            chancesLeft--;
            UpdateTexts();

            if (chancesLeft <= 0)
            {
                OutOfChances?.Invoke();
            }
        }

        public void SaveHighScore()
        {
            highScoreManager.SubmitScore(category, score);
            UpdateHighScoreText();
        }

        public void ResetScore()
        {
            score = 0;
            chancesLeft = startingChances;
            UpdateTexts();
        }

        private void UpdateTexts()
        {
            scoreText.text = score.ToString();
            chancesText.text = chancesLeft.ToString();
        }

        private void UpdateHighScoreText()
        {
            highScoreText.text = highScoreManager.GetHighScore(category).ToString();
        }
    }
}
