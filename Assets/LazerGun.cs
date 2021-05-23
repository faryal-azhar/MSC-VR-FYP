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
            Debug.Log("Laser emit");
            laser.SetActive(true);
        }
        
        public void StopLaserEmission()
        {
            Debug.Log("Laser emit cancel");
            laser.SetActive(false);

        }


    }

}