using System;
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
        public static event Action<string> CheckTheWord;
        AudioSource audioSource;
        List<Balloon> activeBalloons=new List<Balloon>();
        [SerializeField] SpellingUiManager uiManager;
        
        //int hitCount = 0;


        private void Awake()
        {
            Modes.GenerateBalloon += Modes_GenerateBalloon;
            Modes.DestroyBalloon += DestroyActiveBallonns;
            audioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            Modes.GenerateBalloon -= Modes_GenerateBalloon;
            Modes.DestroyBalloon -= DestroyActiveBallonns;
        }


        public void DestroyActiveBallonns()
        {
            if (activeBalloons == null) return;
            foreach(Balloon b in activeBalloons)
            {
                Destroy(b.gameObject);
            }
            activeBalloons.Clear();
        }

        public void OnHitBalloon(char obj)
        {
            audioSource.Play();
            guessedWord += obj;
            uiManager.UpdateUnScrabledWord(guessedWord);
            if (guessedWord.Length == scrambledWord.Length)
            {
                CheckTheWord(guessedWord);
            }
        }

        private void Modes_GenerateBalloon(string word)
        {
            
            scrambledWord = word;
            guessedWord = "";
            Debug.Log("Balloon Generated "+ word );
            activeBalloons.Clear();
            for(int i = 0; i < word.Length; i++)
            {
                Vector3 pos = transform.GetChild(i).position + new Vector3 (0, 3, 0);
                var balloonInstance= Instantiate(balloonPrefab, pos , Quaternion.identity);
                balloonInstance.balloonGenerator = this;
                balloonInstance.transform.parent = transform.GetChild(i);
                balloonInstance.SetBalloonCharacter(word[i]);
                activeBalloons.Add(balloonInstance);
            }
        }
    }
}
