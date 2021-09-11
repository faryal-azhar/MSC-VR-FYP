using UnityEngine;

namespace KidsVR.Activities.Basketball
{
    // Physical button that starts and stops the basketball activity when pushed down.
    public class StartButton : MonoBehaviour
    {
        private const string PressTriggerTag = "buttonDown";
        private const float ReturnSpeed = 0.3f;

        [SerializeField] private BasketballActivity activity;
        [SerializeField] private float minHeight = 0.3f;
        [SerializeField] private float maxHeight = 0.5f;
        [SerializeField] private Color runningColor = Color.green;
        [SerializeField] private Color stoppedColor = Color.red;

        private Renderer buttonRenderer;
        private Vector3 restPosition;

        private void Awake()
        {
            buttonRenderer = GetComponent<Renderer>();
            restPosition = new Vector3(transform.localPosition.x, maxHeight, transform.localPosition.z);
        }

        private void OnEnable()
        {
            activity.RunningChanged += UpdateColor;
        }

        private void OnDisable()
        {
            activity.RunningChanged -= UpdateColor;
        }

        private void Update()
        {
            Vector3 position = transform.localPosition;
            position.y = Mathf.Clamp(position.y, minHeight, maxHeight);
            transform.localPosition = position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag(PressTriggerTag)) return;

            if (activity.IsRunning)
            {
                activity.StopActivity();
            }
            else
            {
                activity.StartActivity();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, restPosition, ReturnSpeed);
        }

        private void UpdateColor(bool isRunning)
        {
            buttonRenderer.material.color = isRunning ? runningColor : stoppedColor;
        }
    }
}
