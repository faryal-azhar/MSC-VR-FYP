using System.Collections;
using TMPro;
using UnityEngine;

namespace KidsVR.Menu
{
    public class ContactPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI popUpText;
        [SerializeField] private string facebookContact;
        [SerializeField] private string emailContact;
        [SerializeField] private float displayTime = 5f;

        private Coroutine hideRoutine;

        private void Start()
        {
            popUpText.enabled = false;
        }

        public void ShowFacebookContact()
        {
            Show(facebookContact);
        }

        public void ShowEmailContact()
        {
            Show(emailContact);
        }

        private void Show(string contact)
        {
            if (hideRoutine != null)
            {
                StopCoroutine(hideRoutine);
            }

            popUpText.text = contact;
            popUpText.enabled = true;
            hideRoutine = StartCoroutine(HideAfterDelay());
        }

        private IEnumerator HideAfterDelay()
        {
            yield return new WaitForSeconds(displayTime);
            popUpText.enabled = false;
            hideRoutine = null;
        }
    }
}
