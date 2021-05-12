using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Door : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       // LockDoor();
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.GetComponent<XRRig>() || other.gameObject.GetComponent<XRController>())
        {
            if (gameObject.isStatic == true)
            {
                Debug.Log("The Door is locked");
            }
            else
            {
                Debug.Log("Door Opened");
            }
        }   
    }
    private void LockDoor()
    {
        gameObject.isStatic = true;
        this.GetComponent<Rigidbody>().isKinematic= true;
    }

    public void UnlockDoor()
    {
        gameObject.isStatic = false;
        this.GetComponent<Rigidbody>().isKinematic = false;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
