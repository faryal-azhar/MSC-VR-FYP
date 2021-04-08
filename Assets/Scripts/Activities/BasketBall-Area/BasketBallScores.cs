using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace BasketBallActivity
{
    public class BasketBallScores : MonoBehaviour
    {
        public int scorePerGaol = 5;
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


        public void IncreaseScore()
        {
            totalScore += scorePerGaol;
            scoreText.text = totalScore.ToString();
        }


        public void DecreaseChances()
        {
            if (chances == 0)
            {
                SetHighScore();
                totalScore = 0;
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
            scoreText.text = "X";
            chancesText.text = "5";
            
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