using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBallActivity
{
    public class ButtonPress : MonoBehaviour
    {
        Vector3 actualPosition;
        float yMaxPosition = 0.5f;
        Vector3 clampedPosition;
        public BasketBallManager manager;
        public BallStand ballStand;
        bool started = false;
        // Start is called before the first frame update
        void Start()
        {
            actualPosition = new Vector3(0, yMaxPosition, 0);
        }

        

        private void OnCollisionEnter(Collision collision)
        {
            if (!started)
            {
                started = true;
                StartTheActivity();
            }

            GetComponent<Renderer>().material.color = Color.green;
             
        }

        private void StartTheActivity()
        {
            ballStand.InstantiateBall();
            manager.StartActivity();
        }

        private void OnCollisionExit(Collision collision)
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, actualPosition, 0.3f);
            GetComponent<Renderer>().material.color = Color.red;

           // Debug.Log("Exiting " + transform.position);
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.localPosition.y > yMaxPosition || transform.localPosition.y<0.3f)
            {
                clampedPosition = transform.localPosition;
                clampedPosition.y = Mathf.Clamp(transform.localPosition.y, 0.3f, yMaxPosition);
                transform.localPosition = clampedPosition;
            }
        }

    }
}
