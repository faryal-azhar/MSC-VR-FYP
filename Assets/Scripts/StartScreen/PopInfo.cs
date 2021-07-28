using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI popUpText;

    [SerializeField] string fbId;
    [SerializeField] string gmailId;

    private void Start()
    {
        popUpText.enabled = false;
    }

    public void ShowFbContact()
    {
        Debug.Log("Click fb");
        StartCoroutine(PopUpContactInfo(fbId));
    }

    public void ShowGmailContact()
    {
        Debug.Log("Click gmail");
        StartCoroutine(PopUpContactInfo(gmailId));
    }

    IEnumerator PopUpContactInfo(string contact)
    {
        if(popUpText.enabled) popUpText.enabled = false;
        popUpText.text = contact;
        popUpText.enabled = true;
        yield return new WaitForSeconds(5f);
        popUpText.enabled = false; 
    }


}
