using UnityEngine;

namespace KidsVR.Activities.Basketball
{
    // Helps the ball into the basket when it gets close, so small kids can still score.
    public class BallAttractor : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float pullStrength = 10f;
        [SerializeField] private float pushForce = 1000f;
        [SerializeField] private float stopDistance = 0.3f;

        private Rigidbody ballBody;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Ball>() != null)
            {
                ballBody = other.attachedRigidbody;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody == ballBody)
            {
                ballBody = null;
            }
        }

        private void OnDisable()
        {
            ballBody = null;
        }

        private void FixedUpdate()
        {
            if (ballBody == null) return;

            Vector3 targetPosition = target.position;
            ballBody.transform.LookAt(target);
            ballBody.MovePosition(Vector3.Slerp(ballBody.position, targetPosition, pullStrength * Time.fixedDeltaTime));
            ballBody.AddRelativeForce(Vector3.forward * pushForce, ForceMode.Force);

            if (Vector3.Distance(ballBody.position, targetPosition) < stopDistance)
            {
                ballBody = null;
            }
        }
    }
}
