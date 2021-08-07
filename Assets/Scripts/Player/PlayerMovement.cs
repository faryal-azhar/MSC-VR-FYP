using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace KidsVR.Player
{
    // Continuous movement with the thumbstick. The character controller follows the headset.
    [RequireComponent(typeof(CharacterController), typeof(XRRig))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float Gravity = -9.81f;
        private const float ExtraHeight = 0.2f;
        private const float GroundCheckOffset = 0.01f;

        [SerializeField] private XRNode inputNode;
        [SerializeField] private float playerSpeed = 1f;
        [SerializeField] private LayerMask floorLayer;

        private CharacterController characterController;
        private XRRig rig;
        private Vector2 inputAxis;
        private float fallingSpeed;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            rig = GetComponent<XRRig>();
        }

        private void Update()
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(inputNode);
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        }

        private void FixedUpdate()
        {
            FollowHeadset();
            Move();
            ApplyGravity();
        }

        private void FollowHeadset()
        {
            characterController.height = rig.cameraInRigSpaceHeight + ExtraHeight;
            Vector3 headPosition = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
            float centerY = characterController.height / 2 + characterController.skinWidth;
            characterController.center = new Vector3(headPosition.x, centerY, headPosition.z);
        }

        private void Move()
        {
            // move where the player is looking, ignoring head tilt
            Quaternion headYaw = Quaternion.Euler(0f, rig.cameraGameObject.transform.eulerAngles.y, 0f);
            Vector3 direction = headYaw * new Vector3(inputAxis.x, 0f, inputAxis.y);
            characterController.Move(direction * (playerSpeed * Time.fixedDeltaTime));
        }

        private void ApplyGravity()
        {
            if (IsOnFloor())
            {
                fallingSpeed = 0f;
                return;
            }

            fallingSpeed += Gravity * Time.fixedDeltaTime;
            characterController.Move(Vector3.up * (fallingSpeed * Time.fixedDeltaTime));
        }

        private bool IsOnFloor()
        {
            Vector3 rayStart = transform.TransformPoint(characterController.center);
            float rayLength = characterController.center.y + GroundCheckOffset;
            return Physics.SphereCast(rayStart, characterController.radius, Vector3.down, out _, rayLength, floorLayer);
        }
    }
}
