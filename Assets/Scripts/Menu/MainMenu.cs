using UnityEngine;
using UnityEngine.SceneManagement;

namespace KidsVR.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject homeCanvas;
        [SerializeField] private GameObject aboutCanvas;
        [SerializeField] private GameObject highScoreCanvas;
        [SerializeField] private string gameSceneName = "2-Level Room";

        private void Awake()
        {
            ShowHome();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        public void ShowHome()
        {
            ShowOnly(homeCanvas);
        }

        public void ShowAbout()
        {
            ShowOnly(aboutCanvas);
        }

        public void ShowHighScores()
        {
            ShowOnly(highScoreCanvas);
        }

        private void ShowOnly(GameObject canvas)
        {
            homeCanvas.SetActive(canvas == homeCanvas);
            aboutCanvas.SetActive(canvas == aboutCanvas);
            highScoreCanvas.SetActive(canvas == highScoreCanvas);
        }
    }
}
