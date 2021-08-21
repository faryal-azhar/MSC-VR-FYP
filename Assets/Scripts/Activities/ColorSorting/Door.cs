using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace KidsVR.Activities.ColorSorting
{
    // Stays locked until the color sorting activity is finished.
    public class Door : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lockedMessage;
        [SerializeField] private GameObject handle;
        [SerializeField] private float messageDuration = 5f;

        private Collider handleCollider;
        private Coroutine messageRoutine;
        private bool isLocked = true;

        private void Awake()
        {
            handleCollider = handle.GetComponent<Collider>();
        }

        private void Start()
        {
            lockedMessage.enabled = false;
            handleCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isLocked) return;

            bool isPlayer = other.GetComponent<XRRig>() != null || other.GetComponent<XRController>() != null;
            if (isPlayer)
            {
                ShowLockedMessage();
            }
        }

        public void Unlock()
        {
            isLocked = false;
            handleCollider.enabled = true;

            if (messageRoutine != null)
            {
                StopCoroutine(messageRoutine);
            }
            Destroy(lockedMessage.gameObject);
        }

        private void ShowLockedMessage()
        {
            if (messageRoutine != null)
            {
                StopCoroutine(messageRoutine);
            }
            messageRoutine = StartCoroutine(ShowMessageForAWhile());
        }

        private IEnumerator ShowMessageForAWhile()
        {
            lockedMessage.enabled = true;
            yield return new WaitForSeconds(messageDuration);
            lockedMessage.enabled = false;
            messageRoutine = null;
        }
    }
}
