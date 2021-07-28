using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Door : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI doorLockedText;
    [SerializeField] GameObject handler;
    bool isLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        doorLockedText.enabled = false;
        LockDoor();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isLocked) return;
       if (other.gameObject.GetComponent<XRRig>() || other.gameObject.GetComponent<XRController>())
        {
            StartCoroutine(ShowDoorLockedPopUp());
        }   
    }

    IEnumerator ShowDoorLockedPopUp()
    {
        doorLockedText.enabled = true;
        yield return new WaitForSeconds(5f);
        doorLockedText.enabled = false;
    }

    private void LockDoor()
    {
        handler.GetComponent<Collider>().enabled = false;
    }

    public void UnlockDoor()
    {
        isLocked = false;
        handler.GetComponent<Collider>().enabled = true;
        Destroy(doorLockedText.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
