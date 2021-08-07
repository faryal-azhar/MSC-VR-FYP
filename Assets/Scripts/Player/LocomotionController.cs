using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace KidsVR.Player
{
    // Teleport ray is only shown while the button is held and the hand is not pointing at something grabbable.
    public class LocomotionController : MonoBehaviour
    {
        [SerializeField] private XRController teleportRay;
        [SerializeField] private InputHelpers.Button teleportActivationButton;
        [SerializeField] private float activationThreshold = 0.1f;
        [SerializeField] private XRRayInteractor rightInteractor;

        public bool EnableTeleport { get; set; } = true;

        private void Update()
        {
            if (!EnableTeleport || teleportRay == null) return;

            bool isPointingAtInteractable = rightInteractor.TryGetHitInfo(out _, out _, out _, out _);
            teleportRay.gameObject.SetActive(IsActivationPressed() && !isPointingAtInteractable);
        }

        private bool IsActivationPressed()
        {
            teleportRay.inputDevice.IsPressed(teleportActivationButton, out bool isPressed, activationThreshold);
            return isPressed;
        }
    }
}
