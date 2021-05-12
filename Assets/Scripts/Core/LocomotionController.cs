using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController teleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public XRRayInteractor rightInteractor;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int index = 0;
        bool validTarget = false;

        if (teleportRay)
        {
            bool isInteractableRayHovering = rightInteractor.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
            teleportRay.gameObject.SetActive(isRayActive(teleportRay) && !isInteractableRayHovering);
        }
        
    }

    public bool isRayActive(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, 
            teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;

    }
}
