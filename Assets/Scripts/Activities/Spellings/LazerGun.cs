using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellingActivity
{
    public class LazerGun : MonoBehaviour
    {
        [SerializeField] GameObject laser;

        public void EmitLaser()
        {
            laser.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
        
        public void StopLaserEmission()
        {
            laser.SetActive(false);
            GetComponent<AudioSource>().Stop();
        }
    }
}