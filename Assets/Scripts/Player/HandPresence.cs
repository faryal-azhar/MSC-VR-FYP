using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace KidsVR.Player
{
    // Spawns an animated hand or the matching controller model for the tracked device.
    public class HandPresence : MonoBehaviour
    {
        private const float PressThreshold = 0.1f;
        private static readonly int TriggerParam = Animator.StringToHash("Trigger");
        private static readonly int GripParam = Animator.StringToHash("Grip");

        [SerializeField] private InputDeviceCharacteristics deviceCharacteristics;
        [SerializeField] private List<GameObject> controllerPrefabs;
        [SerializeField] private GameObject handPrefab;
        [SerializeField] private bool showHand = true;

        private InputDevice targetDevice;
        private GameObject spawnedController;
        private GameObject spawnedHand;
        private Animator handAnimator;

        private void Start()
        {
            TryInitialize();
        }

        private void Update()
        {
            if (!targetDevice.isValid)
            {
                TryInitialize();
                return;
            }

            spawnedHand.SetActive(showHand);
            if (spawnedController != null)
            {
                spawnedController.SetActive(!showHand);
            }

            if (showHand)
            {
                UpdateHandAnimation();
            }
        }

        private void TryInitialize()
        {
            var devices = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(deviceCharacteristics, devices);
            if (devices.Count == 0) return;

            targetDevice = devices[0];
            ClearSpawnedModels();

            GameObject controllerPrefab = controllerPrefabs.Find(prefab => prefab.name == targetDevice.name);
            if (controllerPrefab == null && controllerPrefabs.Count > 0)
            {
                Debug.LogWarning($"No controller model for {targetDevice.name}, using the default one");
                controllerPrefab = controllerPrefabs[0];
            }

            if (controllerPrefab != null)
            {
                spawnedController = Instantiate(controllerPrefab, transform);
            }

            spawnedHand = Instantiate(handPrefab, transform);
            handAnimator = spawnedHand.GetComponent<Animator>();
        }

        private void ClearSpawnedModels()
        {
            if (spawnedController != null) Destroy(spawnedController);
            if (spawnedHand != null) Destroy(spawnedHand);
        }

        private void UpdateHandAnimation()
        {
            handAnimator.SetFloat(TriggerParam, ReadAxis(CommonUsages.trigger));
            handAnimator.SetFloat(GripParam, ReadAxis(CommonUsages.grip));
        }

        private float ReadAxis(InputFeatureUsage<float> usage)
        {
            if (targetDevice.TryGetFeatureValue(usage, out float value) && value > PressThreshold)
            {
                return value;
            }
            return 0f;
        }
    }
}
