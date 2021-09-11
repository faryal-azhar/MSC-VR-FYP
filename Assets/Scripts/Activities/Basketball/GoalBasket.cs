using System;
using TMPro;
using UnityEngine;

namespace KidsVR.Activities.Basketball
{
    [RequireComponent(typeof(AudioSource))]
    public class GoalBasket : MonoBehaviour
    {
        private const string EmptyAnswer = "?";

        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private AudioClip correctAudio;
        [SerializeField] private AudioClip incorrectAudio;
        [SerializeField] private GameObject fireworkVfx;
        [SerializeField] private Transform fireworkVfxPoint;
        [SerializeField] private float fireworkLifetime = 5f;

        private AudioSource audioSource;
        private bool ballEnteredRim;

        public event Action<GoalBasket> BallScored;

        public bool IsCorrect { get; private set; }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void SetAnswer(int answer, bool isCorrect)
        {
            valueText.text = answer.ToString();
            IsCorrect = isCorrect;
        }

        public void ClearAnswer()
        {
            valueText.text = EmptyAnswer;
            IsCorrect = false;
        }

        public void ArmGoal()
        {
            ballEnteredRim = true;
        }

        public void ResetShot()
        {
            ballEnteredRim = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!ballEnteredRim || other.GetComponent<Ball>() == null) return;

            ballEnteredRim = false;
            BallScored?.Invoke(this);
        }

        public void PlayCorrectFeedback()
        {
            audioSource.PlayOneShot(correctAudio);

            GameObject firework = Instantiate(fireworkVfx, fireworkVfxPoint.position, Quaternion.identity, fireworkVfxPoint);
            foreach (ParticleSystem particles in firework.GetComponentsInChildren<ParticleSystem>())
            {
                particles.Play();
            }
            Destroy(firework, fireworkLifetime);
        }

        public void PlayWrongFeedback()
        {
            audioSource.PlayOneShot(incorrectAudio);
        }
    }
}
