using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace BasketBallActivity
{
    public class Ball : MonoBehaviour
    {
        private GoalBasket goalBasket;
        [SerializeField] bool isTriggerBasket = false;
        BallStand ballStand;
        bool hasBallGenerated = false;
        AudioSource audioSource;
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void SetBallStand(BallStand instance)
        {
            ballStand = instance;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "floor")
            {
                audioSource.Play();
                if (isTriggerBasket)
                {
                    BallHitGround();
                   // Debug.Log("Hit ground check");
                }
                else
                {
                    if(!hasBallGenerated)
                        CheckForBall();
                }
            }
        }

        private void CheckForBall()
        {
            hasBallGenerated = true;
            //Debug.Log("Collided with ground");
            Destroy(this.GetComponent<XRGrabInteractable>());
            Debug.Log("Check1");
            ballStand.InstantiateBall(true);
            DestroyBall(1f);

        }


        public void DestroyBall(float time)
        {
            Destroy(gameObject, time);
        }

        private void BallHitGround()
        {
            goalBasket.ResetTriggers();
            isTriggerBasket = false;
        }

        public void SetTriggerBasket(GoalBasket basket)
        {
            isTriggerBasket = true;
            goalBasket = basket;
        }
    }
}

