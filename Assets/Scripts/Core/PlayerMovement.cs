using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private XRNode inputNode;
    private Vector2 inputAxis;
    private CharacterController playerController;
    [SerializeField] private float playerSpeed = 1f;
    private XRRig playerRig;
    private float gravity = -9.81f;
    private float fallingSpeed;
    private float additionalHeight = 0.2f;
    [SerializeField] private LayerMask floorLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerRig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputNode);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        // if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis) && inputAxis != Vector2.zero)
        // {
        //     Debug.Log(inputAxis);
        // }
        
        
    }

    private void FixedUpdate()
    {
        //ControllerFollowHeadset();    //To make capsule follow headset
        Quaternion headRotation = Quaternion.Euler(0f,playerRig.cameraGameObject.transform.eulerAngles.y,0f);
        //Set direction of player according to the rotation of vr headset
        Vector3 direction =headRotation * new Vector3(inputAxis.x, 0f, inputAxis.y);
        playerController.Move(direction * (Time.fixedDeltaTime * playerSpeed));    //move player

       PlayerFall();    //If player is not on ground then he will fall
    }

    void PlayerFall()
    {
        if (PlayerOnFLoor())
        {
            fallingSpeed = 0f;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
            playerController.Move(Vector3.up * (fallingSpeed * Time.fixedDeltaTime));
        }
        
    }

    void ControllerFollowHeadset()
    {
        playerController.height = playerRig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 controllerCenter = transform.InverseTransformPoint(playerRig.cameraGameObject.transform.position);
        playerController.center=new Vector3(controllerCenter.x,playerController.height/2 + playerController.skinWidth ,controllerCenter.z);
    }

    bool PlayerOnFLoor()
    {
        Vector3 rayStart = transform.TransformPoint(playerController.center);
        float rayLength = playerController.center.y + 0.01f;
        bool rayHit = Physics.SphereCast(rayStart, playerController.radius, Vector3.down,
            out RaycastHit hitInfo, rayLength, floorLayer);
        return rayHit;

    }
}
