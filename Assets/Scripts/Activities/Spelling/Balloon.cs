using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KidsVR.Activities.Spelling
{
    public class Balloon : MonoBehaviour
    {
        private const string LaserName = "laser";
        private static readonly Color[] Colors = { Color.cyan, Color.red, Color.yellow, Color.magenta, Color.blue, Color.green };

        [SerializeField] private TextMeshProUGUI letterText;
        [SerializeField] private ParticleSystem popVfx;

        private bool isPopped;

        public event Action<Balloon> Popped;

        public char Letter { get; private set; }

        private void Start()
        {
            GetComponent<Renderer>().material.color = Colors[Random.Range(0, Colors.Length)];
        }

        public void SetLetter(char letter)
        {
            Letter = letter;
            letterText.text = letter.ToString();
        }

        private void OnParticleCollision(GameObject other)
        {
            // the laser hits many times per frame, only pop once
            if (isPopped || other.name != LaserName) return;

            isPopped = true;
            Popped?.Invoke(this);
            Instantiate(popVfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
