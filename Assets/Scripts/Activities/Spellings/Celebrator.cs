using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellingActivity
{
    public class Celebrator : MonoBehaviour
    {
        [SerializeField] Animator foxAnimator;
        [SerializeField] Animator catAnimator;
        [SerializeField] ParticleSystem leftFirework;
        [SerializeField] ParticleSystem rightFriework;

        public void Celebration()
        {
            catAnimator.SetTrigger("jump");
            foxAnimator.SetTrigger("jump");
            leftFirework.Play();
            rightFriework.Play();
        }
    }
}
