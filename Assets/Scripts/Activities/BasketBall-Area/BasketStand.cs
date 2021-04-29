using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BasketBallActivity
{
    [RequireComponent(typeof(AudioSource))]
    public class BasketStand : MonoBehaviour
    {
        public GoalBasket goalBasket;
        [SerializeField] ParticleSystem hitVfx;
        [SerializeField] Transform hitVfxPoint;
        AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Ball>())
            {
                //Debug.Log("Trigger check");
                PlaySfx();
                PlayVfx();
                SetTriggers(other);
            }
        }

        private void SetTriggers(Collider other)
        {
            other.GetComponent<Ball>().SetTriggerBasket(goalBasket);
            goalBasket.SetBallTriggeredBaketStand();
        }

        private void PlayVfx()
        {
            var hitVfxInstance = Instantiate(hitVfx, hitVfxPoint.position, Quaternion.identity);
            hitVfxInstance.Play();
            hitVfxInstance.transform.parent = hitVfxPoint.transform;
            Destroy(hitVfxInstance.gameObject, hitVfxInstance.main.duration);
        }

        private void PlaySfx()
        {
            audioSource.Play();
        }
    }
}

