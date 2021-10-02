using System;
using System.Collections.Generic;
using UnityEngine;

namespace KidsVR.Activities.Spelling
{
    // Spawns one balloon per letter above each child slot and collects the letters as they get popped.
    [RequireComponent(typeof(AudioSource))]
    public class BalloonSpawner : MonoBehaviour
    {
        [SerializeField] private Balloon balloonPrefab;
        [SerializeField] private SpellingUI ui;
        [SerializeField] private float spawnHeight = 3f;

        private readonly List<Balloon> activeBalloons = new List<Balloon>();
        private AudioSource popSound;
        private string targetWord = string.Empty;
        private string guessedWord = string.Empty;

        public event Action<string> WordCompleted;

        private void Awake()
        {
            popSound = GetComponent<AudioSource>();
        }

        public void Spawn(string word)
        {
            Clear();

            if (word.Length > transform.childCount)
            {
                Debug.LogError($"Not enough balloon slots for \"{word}\"");
                return;
            }

            targetWord = word;
            for (int i = 0; i < word.Length; i++)
            {
                Transform slot = transform.GetChild(i);
                Balloon balloon = Instantiate(balloonPrefab, slot.position + Vector3.up * spawnHeight, Quaternion.identity, slot);
                balloon.SetLetter(word[i]);
                balloon.Popped += OnBalloonPopped;
                activeBalloons.Add(balloon);
            }
        }

        public void Clear()
        {
            foreach (Balloon balloon in activeBalloons)
            {
                Destroy(balloon.gameObject);
            }

            activeBalloons.Clear();
            targetWord = string.Empty;
            guessedWord = string.Empty;
            ui.ShowGuess(guessedWord);
        }

        private void OnBalloonPopped(Balloon balloon)
        {
            popSound.Play();
            activeBalloons.Remove(balloon);

            guessedWord += balloon.Letter;
            ui.ShowGuess(guessedWord);

            if (guessedWord.Length == targetWord.Length)
            {
                WordCompleted?.Invoke(guessedWord);
            }
        }
    }
}
