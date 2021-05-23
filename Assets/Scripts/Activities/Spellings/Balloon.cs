using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpellingActivity
{
    public class Balloon : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI characterText;
        [SerializeField] char containedCharacter;
        private Color[] colors = { Color.cyan, Color.red, Color.yellow, Color.magenta, Color.blue, Color.green };
        [SerializeField] ParticleSystem popVfx;
        public BalloonGenerator balloonGenerator;
        

        private void Start()
        {
            GetComponent<Renderer>().material.color = colors[UnityEngine.Random.Range(0, colors.Length)];
        }

        public void SetBalloonCharacter(char character)
        {
            containedCharacter = character;
            characterText.text = character.ToString();
        }


        private void OnParticleCollision(GameObject other)
        {
            //GetComponent<SphereCollider>().enabled = false;
                 if (other.name != "laser") return;
                balloonGenerator.OnHitBalloon(containedCharacter);
                Instantiate(popVfx, transform.position, Quaternion.identity);
                Destroy(gameObject);
            
        }


    }
}
