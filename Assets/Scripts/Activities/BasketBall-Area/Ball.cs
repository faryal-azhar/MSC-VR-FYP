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
                        GenerateNewBall();
                }
            }
        }

        private void GenerateNewBall()
        {
            hasBallGenerated = true;
            //Debug.Log("Collided with ground");
            ballStand.InstantiateBall();
            Destroy(this.GetComponent<XRGrabInteractable>());
            Destroy(gameObject,1f);
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

