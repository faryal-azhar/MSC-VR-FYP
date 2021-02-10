using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandCheck : MonoBehaviour
{
    private InputDevice _targetDevice;
    [SerializeField] InputDeviceCharacteristics _inputDeviceCharacteristics;
    [SerializeField] private List<GameObject> _controllerPrefabs;
    private GameObject _selectedController;
    private GameObject _spawnedControllerPrefab;
    [SerializeField] private GameObject _handPrefab;
    private GameObject _spawnedHandPrefab;
    [SerializeField] private bool _showHand=true;
    private Animator _handAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeAllContoller();
    }

    void InitializeAllContoller()
    {
        List<InputDevice> devices= new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(_inputDeviceCharacteristics,devices);
        if (devices.Count > 0)
        {
            _targetDevice = devices[0]; 
            
            _selectedController= _controllerPrefabs.Find(controller => controller.name == _targetDevice.name);
            if (_selectedController != null)
            {
                _spawnedControllerPrefab = Instantiate(_selectedController, transform);
            }
            else
            {
                //todo Default controller Prefab
            }
            
            _spawnedHandPrefab = Instantiate(_handPrefab, transform);
            _handAnimator = _spawnedHandPrefab.GetComponent<Animator>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!_targetDevice.isValid)
        {
            InitializeAllContoller();
        }
        else
        {
            UpdateControllers();
        }

    }

    void UpdateControllers()
    {
        if (_showHand)
        {
            _spawnedControllerPrefab.SetActive(false);
            _spawnedHandPrefab.SetActive(true);
            UpdateHandAnimation();
        }
        else
        {
            _spawnedControllerPrefab.SetActive(true);
            _spawnedHandPrefab.SetActive(false);
        }

    }

    void UpdateHandAnimation()
    {
        if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1)
        {
            _handAnimator.SetFloat("Trigger",triggerValue);
        }
        else
        {
            _handAnimator.SetFloat("Trigger",0f);
        }

        if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1)
        {
            _handAnimator.SetFloat("Grip",gripValue);
        }
        else
        {
            _handAnimator.SetFloat("Grip",0f);
        }
    }
}
