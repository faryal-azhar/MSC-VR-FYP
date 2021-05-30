using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellingActivity
{
    public class GunStand : MonoBehaviour
    {
        [SerializeField] LazerGun gunPrefab;
        [SerializeField] Transform pointOfInstantiate;
        LazerGun instanceOfGun=null;

        public void GenerateGun()
        {
            if (instanceOfGun) Destroy(instanceOfGun.gameObject);
            instanceOfGun=Instantiate(gunPrefab, pointOfInstantiate.position, gunPrefab.transform.rotation);
            //instanceOfGun
        }
    }
}
