using KidsVR.HighScores;
using TMPro;
using UnityEngine;

namespace KidsVR.Menu
{
    public class HighScoreBoard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI spellingText;
        [SerializeField] private TextMeshProUGUI additionText;
        [SerializeField] private TextMeshProUGUI subtractionText;
        [SerializeField] private TextMeshProUGUI multiplicationText;
        [SerializeField] private TextMeshProUGUI divisionText;

        private void Start()
        {
            var highScores = new HighScoreRepository();

            spellingText.text = highScores.Get(HighScoreCategory.Spelling).ToString();
            additionText.text = highScores.Get(HighScoreCategory.BasketballAddition).ToString();
            subtractionText.text = highScores.Get(HighScoreCategory.BasketballSubtraction).ToString();
            multiplicationText.text = highScores.Get(HighScoreCategory.BasketballMultiplication).ToString();
            divisionText.text = highScores.Get(HighScoreCategory.BasketballDivision).ToString();
        }
    }
}
