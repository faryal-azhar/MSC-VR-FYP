using UnityEngine;

namespace KidsVR.Activities.Spelling
{
    public class Celebrator : MonoBehaviour
    {
        private static readonly int JumpTrigger = Animator.StringToHash("jump");

        [SerializeField] private Animator foxAnimator;
        [SerializeField] private Animator catAnimator;
        [SerializeField] private ParticleSystem leftFirework;
        [SerializeField] private ParticleSystem rightFirework;

        public void Celebrate()
        {
            foxAnimator.SetTrigger(JumpTrigger);
            catAnimator.SetTrigger(JumpTrigger);
            leftFirework.Play();
            rightFirework.Play();
        }
    }
}
