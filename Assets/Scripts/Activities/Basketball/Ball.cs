using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace KidsVR.Activities.Basketball
{
    [RequireComponent(typeof(AudioSource))]
    public class Ball : MonoBehaviour
    {
        private const string FloorTag = "floor";
        private const float DestroyDelay = 1f;

        private BallStand stand;
        private GoalBasket hoopEntered;
        private bool isReplaced;
        private AudioSource bounceSound;

        private void Awake()
        {
            bounceSound = GetComponent<AudioSource>();
        }

        public void SetStand(BallStand ballStand)
        {
            stand = ballStand;
        }

        public void EnterHoop(GoalBasket basket)
        {
            hoopEntered = basket;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag(FloorTag)) return;

            bounceSound.Play();

            if (hoopEntered != null)
            {
                // the shot is over, next bounce on the floor will replace the ball
                hoopEntered.ResetShot();
                hoopEntered = null;
            }
            else if (!isReplaced)
            {
                Replace();
            }
        }

        private void Replace()
        {
            isReplaced = true;
            Destroy(GetComponent<XRGrabInteractable>());
            stand.ReplaceBall();
            Destroy(gameObject, DestroyDelay);
        }
    }
}
