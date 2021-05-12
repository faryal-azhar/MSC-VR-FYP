using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellingActivity
{
    public class BalloonGenerator : MonoBehaviour
    {
        [SerializeField] Balloon balloonPrefab;
        string guessedWord = "";
        string scrambledWord;


        private void Awake()
        {
            Modes.GenerateBalloon += Modes_GenerateBalloon;
            Balloon.OnHitBalloon += Balloon_OnHitBalloon;
        }

        private void Balloon_OnHitBalloon(char obj)
        {
            guessedWord += obj;
            if (guessedWord.Length == scrambledWord.Length)
            {
                Debug.Log("Yesss " + guessedWord);
            }
        }

        private void Modes_GenerateBalloon(string word)
        {
            guessedWord = "";
            scrambledWord = word;
            Debug.Log("Balloon Generated "+word );
            for(int i = 0; i < word.Length; i++)
            {
                Vector3 pos = transform.GetChild(i).position + new Vector3 (0, 3, 0);
                var balloonInstance= Instantiate(balloonPrefab, pos , Quaternion.identity);
                balloonInstance.transform.parent = transform.GetChild(i);
                balloonInstance.SetBalloonCharacter(word[i]);
            }
        }
    }
}
