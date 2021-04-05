using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BasketBallActivity
{
    public class GoalBasket : MonoBehaviour
    {
        [SerializeField] private bool goal = false;
        [SerializeField] private bool ballTriggeredBasketStand = false;
        public TextMeshProUGUI valueText;
        public int value;
        public bool correctBasket = false;
        public BasketBallScores score;
        [SerializeField] AudioClip correctAudio;
        [SerializeField] AudioClip incorrectAudio;
        [SerializeField] GameObject fireworkVfx;
        [SerializeField] Transform fireworkVfxPoint;
        AudioSource audioSource;
        // Start is called before the first frame update

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void SetBallTriggeredBaketStand()
        {
            ballTriggeredBasketStand = true;
           // Debug.Log(ballTriggeredBasketStand);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (ballTriggeredBasketStand)
            {
                goal = true;
                if(goal && correctBasket)
                {
                    score.IncreaseScore(); //Increase Score
                    audioSource.PlayOneShot(correctAudio);
                    PlayFireworkVfx();
                    SetCorrectBasket(false); 
                    score.GetComponent<BasketBallManager>().StartActivity(); //restart activity
                }
                else
                {
                    score.DecreaseChances();
                    audioSource.PlayOneShot(incorrectAudio);
                }
            }
        }

        private void PlayFireworkVfx()
        {
            var fireworkInstance = Instantiate(fireworkVfx, fireworkVfxPoint.position, Quaternion.identity);
            fireworkInstance.transform.parent = fireworkVfxPoint;
            foreach(var child in fireworkInstance.GetComponentsInChildren<ParticleSystem>())
            {
                child.Play();
            }
            Destroy(fireworkInstance.gameObject, 5f);
        }

        public void ResetTriggers()
        {
            ballTriggeredBasketStand = false;
            goal = false;
        }

        public void SetCorrectBasket(bool value)
        {
            correctBasket = value;
        }

        public void SetValue(int number)
        {
            value = number;
            UpdateUiValue();
        }

        private void UpdateUiValue()
        {
            valueText.text = value.ToString();
        }
    }
}

