using System.Collections;
using KidsVR.Activities.Spelling.Words;
using KidsVR.Core;
using KidsVR.HighScores;
using UnityEngine;

namespace KidsVR.Activities.Spelling
{
    // Shows a scrambled word on balloons. The kid shoots the balloons in the right order to spell it.
    [RequireComponent(typeof(AudioSource), typeof(Celebrator))]
    public class SpellingActivity : MonoBehaviour, IActivity
    {
        [SerializeField] private ActivityScheduler activityScheduler;
        [SerializeField] private HighScoreManager highScoreManager;
        [SerializeField] private SpellingUI ui;
        [SerializeField] private BalloonSpawner balloonSpawner;
        [SerializeField] private float resultDelay = 3f;

        [Header("Words")]
        [SerializeField] private TextAsset dictionaryFile;
        [SerializeField] private SpellingLevel easy;
        [SerializeField] private SpellingLevel medium;
        [SerializeField] private SpellingLevel hard;

        [Header("Audio")]
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClip correctSound;
        [SerializeField] private AudioClip wrongSound;

        private AudioSource audioSource;
        private Celebrator celebrator;
        private WordDictionary dictionary;
        private SpellingLevel currentLevel;
        private string[] currentWords;
        private string scrambledWord;
        private int score;

        public bool IsRunning { get; private set; }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            celebrator = GetComponent<Celebrator>();
            dictionary = new WordDictionary(dictionaryFile.text);
            SetDifficulty(SpellingDifficulty.Easy);

            balloonSpawner.WordCompleted += CheckWord;
        }

        private void OnDestroy()
        {
            balloonSpawner.WordCompleted -= CheckWord;
        }

        public void SetDifficulty(SpellingDifficulty difficulty)
        {
            currentLevel = GetLevel(difficulty);
            currentWords = WordList.Parse(currentLevel.wordList.text);
        }

        public void StartActivity()
        {
            if (IsRunning) return;

            IsRunning = true;
            score = 0;
            ui.ShowScore(score);
            activityScheduler.Begin(this, backgroundMusic);
            ShowNextWord();
        }

        public void StopActivity()
        {
            if (!IsRunning) return;

            IsRunning = false;
            StopAllCoroutines();
            balloonSpawner.Clear();
            highScoreManager.SubmitScore(HighScoreCategory.Spelling, score);
            ui.Clear();
            activityScheduler.End(this);
        }

        private void ShowNextWord()
        {
            string word = currentWords[Random.Range(0, currentWords.Length)];
            scrambledWord = WordScrambler.Scramble(word);
            ui.ShowScrambledWord(scrambledWord);
            balloonSpawner.Spawn(scrambledWord);
        }

        private void CheckWord(string guessedWord)
        {
            if (!IsRunning) return;

            // any real word made from the same letters is accepted, not only the original one
            StartCoroutine(dictionary.Contains(guessedWord) ? CorrectGuess() : WrongGuess());
        }

        private IEnumerator CorrectGuess()
        {
            celebrator.Celebrate();
            ui.ShowCorrect();
            audioSource.PlayOneShot(correctSound);

            score += currentLevel.pointsPerWord;
            ui.ShowScore(score);
            highScoreManager.SubmitScore(HighScoreCategory.Spelling, score);

            yield return new WaitForSeconds(resultDelay);
            ui.ClearResult();
            ShowNextWord();
        }

        private IEnumerator WrongGuess()
        {
            ui.ShowWrong();
            audioSource.PlayOneShot(wrongSound);

            yield return new WaitForSeconds(resultDelay);
            ui.ClearResult();
            balloonSpawner.Spawn(scrambledWord);
        }

        private SpellingLevel GetLevel(SpellingDifficulty difficulty)
        {
            switch (difficulty)
            {
                case SpellingDifficulty.Medium: return medium;
                case SpellingDifficulty.Hard: return hard;
                default: return easy;
            }
        }
    }
}
