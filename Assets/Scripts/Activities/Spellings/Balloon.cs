using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpellingActivity
{
    public class Balloon : MonoBehaviour
    {
        [SerializeField] Text characterText;
        [SerializeField] char containedCharacter;
        private Color[] colors = { Color.cyan, Color.red, Color.yellow, Color.magenta, Color.blue, Color.green };
        public static event Action<char> OnHitBalloon;
        
        

        private void Start()
        {
            GetComponent<Renderer>().material.color = colors[UnityEngine.Random.Range(0, colors.Length)];
        }

        public void SetBalloonCharacter(char character)
        {
            containedCharacter = character;
            characterText.text = character.ToString();
        }

        private void OnTriggerEnter(Collider other)
        {
            //GetComponent<SphereCollider>().enabled = false;
            if (OnHitBalloon != null)
                OnHitBalloon(containedCharacter);
            Destroy(gameObject);
        }


    }
}
