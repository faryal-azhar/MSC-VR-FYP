using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace BasketBallActivity
{
    public class BasketBallManager : MonoBehaviour
    {

        public GoalBasket[] targetBaskets;
        public ActivityType activityType;
        int number1, number2;   //to store random two operands
        int index1, index2, index3; //store indexes in random order
        int incorrectResult1, incorrectResult2, correctResult;
        public TextMeshProUGUI questionText;
        BasketBallScores basketBallScores;
        int minNumber=1, maxNumber=11;

        public void StartActivity()
        {
            basketBallScores = GetComponent<BasketBallScores>();
            //if(minNumber==0 || maxNumber==0) SetMinMaxRange(1, 11);
            GenerateQuestion();
            GenerateRandomResult();
            GenerateRandomIndex();
            AssignValuesToGoalBasket(true);
        }

        public void SetMinMaxRange(int min,int max)
        {
            minNumber = min;
            maxNumber = max;
        }

        public void QuitActivity()
        {
            number1 = number2 =
            incorrectResult1 = incorrectResult2 = correctResult = 0;
            questionText.text = "? + ? = ?";
            AssignValuesToGoalBasket(false);
            index1 = index2 = index3 = 0;
            basketBallScores.SetHighScore();
            basketBallScores.ResetScores();

        }

        private void GenerateQuestion()
        {
            number1 = Random.Range(minNumber, maxNumber);
            number2 = Random.Range(minNumber, maxNumber);
            switch (activityType)
            {
                case ActivityType.addition:
                    correctResult= number1 + number2;
                    UpdateQuestionUiText('+');
                    break;
                case ActivityType.subtraction:
                    correctResult = number1 - number2;
                    UpdateQuestionUiText('-');
                    break;
                case ActivityType.multiplication:
                    correctResult = number1 * number2;
                    UpdateQuestionUiText('x');
                    break;
                case ActivityType.division:
                    correctResult = number1 / number2;
                    UpdateQuestionUiText('/');
                    break;
            }  
            
        }

        private void UpdateQuestionUiText(char op)
        {
            string qText = $"{number1} {op} {number2} = ?";
            questionText.text= qText;
        }

        private void GenerateRandomResult()
        {
            incorrectResult1 = Random.Range(correctResult - 5, correctResult + 8);
            if (incorrectResult1 == correctResult)
                incorrectResult1 += Random.Range(1, 5);
            do
            {
                incorrectResult2 = Random.Range(correctResult - 5, correctResult + 8);
            }
            while (incorrectResult2 == incorrectResult1 || incorrectResult2 == correctResult);

           // Debug.Log($"{incorrectResult1},,, {incorrectResult2},,, {correctResult}");

        }

        private void GenerateRandomIndex()
        {
            List<int> numbers = new List<int>();
            numbers.Add(0); numbers.Add(1); numbers.Add(2);
            index1 = numbers[Random.Range(0,numbers.Count)];
            numbers.Remove(index1);
            index2 = numbers[Random.Range(0, numbers.Count)];
            numbers.Remove(index2);
            index3 = numbers[0];
            
           // Debug.Log($"index1= {index1},, index2={index2},, index3={index3}");
        }


        private void AssignValuesToGoalBasket(bool val)
        {
            targetBaskets[index1].SetValue(incorrectResult1);
            targetBaskets[index2].SetValue(incorrectResult2);
            targetBaskets[index3].SetValue(correctResult);

            targetBaskets[index3].SetCorrectBasket(val);

        }

        public enum ActivityType
        {
            addition,
            subtraction,
            multiplication,
            division
        }
    }

}

