using System;
using System.Collections.Generic;
using KidsVR.Activities.Basketball.Questions;
using KidsVR.Core;
using KidsVR.HighScores;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KidsVR.Activities.Basketball
{
    // Shows a math question and puts possible answers on the baskets. The kid has to score in the right one.
    [RequireComponent(typeof(BasketballScore))]
    public class BasketballActivity : MonoBehaviour, IActivity
    {
        private const string EmptyQuestion = "? + ? = ?";
        private const int MinWrongOffset = -5;
        private const int MaxWrongOffset = 8;

        [SerializeField] private ActivityScheduler activityScheduler;
        [SerializeField] private OperationType operation;
        [SerializeField] private GoalBasket[] baskets;
        [SerializeField] private BallStand ballStand;
        [SerializeField] private BallAttractor[] ballAttractors;
        [SerializeField] private TextMeshProUGUI questionText;
        [SerializeField] private AudioClip backgroundMusic;

        private BasketballScore score;
        private IMathOperation mathOperation;
        private int minNumber = 1;
        private int maxNumber = 11;

        public event Action<bool> RunningChanged;

        public bool IsRunning { get; private set; }
        public BasketballScore Score => score;

        private void Awake()
        {
            score = GetComponent<BasketballScore>();
            mathOperation = MathOperationFactory.Create(operation);
        }

        private void Start()
        {
            score.Initialize(ToHighScoreCategory(operation));
        }

        private void OnEnable()
        {
            score.OutOfChances += OnOutOfChances;
            foreach (GoalBasket basket in baskets)
            {
                basket.BallScored += OnBallScored;
            }
        }

        private void OnDisable()
        {
            score.OutOfChances -= OnOutOfChances;
            foreach (GoalBasket basket in baskets)
            {
                basket.BallScored -= OnBallScored;
            }
        }

        public void SetNumberRange(int min, int max)
        {
            minNumber = min;
            maxNumber = max;
        }

        public void StartActivity()
        {
            if (IsRunning) return;

            IsRunning = true;
            activityScheduler.Begin(this, backgroundMusic);
            score.ResetScore();
            ballStand.SpawnBall();
            SetAttractorsActive(true);
            AskNextQuestion();
            RunningChanged?.Invoke(true);
        }

        public void StopActivity()
        {
            if (!IsRunning) return;

            IsRunning = false;
            score.SaveHighScore();
            score.ResetScore();
            ballStand.RemoveBall();
            SetAttractorsActive(false);
            ClearQuestion();
            activityScheduler.End(this);
            RunningChanged?.Invoke(false);
        }

        private void AskNextQuestion()
        {
            MathQuestion question = mathOperation.CreateQuestion(minNumber, maxNumber);
            questionText.text = question.ToString();

            List<int> answers = CreateAnswers(question.Answer, baskets.Length);
            for (int i = 0; i < baskets.Length; i++)
            {
                baskets[i].SetAnswer(answers[i], answers[i] == question.Answer);
            }
        }

        // one correct answer and a few close wrong ones, in random order
        private static List<int> CreateAnswers(int correctAnswer, int count)
        {
            var answers = new List<int> { correctAnswer };
            while (answers.Count < count)
            {
                int wrongAnswer = correctAnswer + Random.Range(MinWrongOffset, MaxWrongOffset);
                if (wrongAnswer >= 0 && !answers.Contains(wrongAnswer))
                {
                    answers.Add(wrongAnswer);
                }
            }

            answers.Shuffle();
            return answers;
        }

        private void ClearQuestion()
        {
            questionText.text = EmptyQuestion;
            foreach (GoalBasket basket in baskets)
            {
                basket.ClearAnswer();
            }
        }

        private void OnBallScored(GoalBasket basket)
        {
            if (!IsRunning) return;

            if (basket.IsCorrect)
            {
                basket.PlayCorrectFeedback();
                score.AddGoal();
                AskNextQuestion();
            }
            else
            {
                basket.PlayWrongFeedback();
                score.LoseChance();
            }
        }

        private void OnOutOfChances()
        {
            score.SaveHighScore();
            score.ResetScore();
        }

        private void SetAttractorsActive(bool isActive)
        {
            foreach (BallAttractor attractor in ballAttractors)
            {
                attractor.gameObject.SetActive(isActive);
            }
        }

        private static HighScoreCategory ToHighScoreCategory(OperationType type)
        {
            switch (type)
            {
                case OperationType.Addition: return HighScoreCategory.BasketballAddition;
                case OperationType.Subtraction: return HighScoreCategory.BasketballSubtraction;
                case OperationType.Multiplication: return HighScoreCategory.BasketballMultiplication;
                case OperationType.Division: return HighScoreCategory.BasketballDivision;
                default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
