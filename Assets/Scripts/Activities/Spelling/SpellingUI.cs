using TMPro;
using UnityEngine;

namespace KidsVR.Activities.Spelling
{
    public class SpellingUI : MonoBehaviour
    {
        private const string ScrambledPlaceholder = "Scrambled";
        private const string CorrectMessage = "Yayyy!!";
        private const string WrongMessage = "Oops, Try Again.";

        [SerializeField] private TextMeshProUGUI scrambledWordText;
        [SerializeField] private TextMeshProUGUI guessText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI resultText;

        public void ShowScrambledWord(string word)
        {
            scrambledWordText.text = word;
        }

        public void ShowGuess(string guess)
        {
            guessText.text = guess;
        }

        public void ShowScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void ShowCorrect()
        {
            resultText.text = CorrectMessage;
        }

        public void ShowWrong()
        {
            resultText.text = WrongMessage;
        }

        public void ClearResult()
        {
            resultText.text = string.Empty;
        }

        public void Clear()
        {
            scrambledWordText.text = ScrambledPlaceholder;
            guessText.text = string.Empty;
            scoreText.text = string.Empty;
            resultText.text = string.Empty;
        }
    }
}
