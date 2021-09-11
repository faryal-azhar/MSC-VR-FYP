using UnityEngine;

namespace KidsVR.Activities.Basketball
{
    // Trigger at the top of the hoop. A goal only counts if the ball came in from here.
    [RequireComponent(typeof(AudioSource))]
    public class BasketRim : MonoBehaviour
    {
        [SerializeField] private GoalBasket goalBasket;
        [SerializeField] private ParticleSystem hitVfx;
        [SerializeField] private Transform hitVfxPoint;

        private AudioSource hitSound;

        private void Awake()
        {
            hitSound = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var ball = other.GetComponent<Ball>();
            if (ball == null) return;

            hitSound.Play();
            PlayVfx();
            ball.EnterHoop(goalBasket);
            goalBasket.ArmGoal();
        }

        private void PlayVfx()
        {
            ParticleSystem vfx = Instantiate(hitVfx, hitVfxPoint.position, Quaternion.identity, hitVfxPoint);
            vfx.Play();
            Destroy(vfx.gameObject, vfx.main.duration);
        }
    }
}
