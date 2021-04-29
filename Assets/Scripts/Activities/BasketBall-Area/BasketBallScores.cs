using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace BasketBallActivity
{
    public class BasketBallScores : MonoBehaviour
    {
        public int scorePerGoal = 5;
        public int totalScore = 0;
        public int chances = 5;
        public int highScore = 0;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] TextMeshProUGUI chancesText;
        [SerializeField] TextMeshProUGUI highScoreText;


        private void Start()
        {
            chancesText.text = chances.ToString();
        }

        public void SetScoresPerGoal(int score)
        {
            scorePerGoal = score;
        }


        public void IncreaseScore()
        {
            totalScore += scorePerGoal;
            scoreText.text = totalScore.ToString();
        }


        public void DecreaseChances()
        {
            if (chances == 0)
            {   
                ResetScores();
                Debug.Log("You lost");  //Restart the activity-- restart score
            }
            else
            {
                chances -= 1;
                chancesText.text = chances.ToString();
            }
        }

        public void ResetScores()
        {
            SetHighScore();
            totalScore = 0;
            chances = 5;
            UpdateTexts();
        }

        void UpdateTexts()
        {
            scoreText.text = totalScore.ToString();
            chancesText.text = chances.ToString();
        }

        public void SetHighScore()
        {
            if (highScore < totalScore)
            {
                highScore = totalScore;
                highScoreText.text = highScore.ToString();
            }   
        }
 
       
    }

}