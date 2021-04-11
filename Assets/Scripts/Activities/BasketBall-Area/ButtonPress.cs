using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBallActivity
{
    public class ButtonPress : MonoBehaviour
    {
        //bool isOn = false;
        Vector3 actualPosition;
        float yMaxPosition = 0.5f;
        Vector3 clampedPosition;
        public BasketBallManager manager;
        public BallStand ballStand;
        bool started = false;
        [SerializeField] BallAttractor[] ballAttractors;
        // Start is called before the first frame update
        void Start()
        {
            actualPosition = new Vector3(0, yMaxPosition, 0);
        }

        

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("triggered");
            if(collision.collider.tag== "buttonDown")
            {
                if (!started)
                {
                    started = true;
                    StartTheActivity();
                    GetComponent<Renderer>().material.color = Color.green;
                }

                else if (started)
                {
                    started = false;
                    QuitActivity();
                    GetComponent<Renderer>().material.color = Color.red;
                }
            }
            
        }

        private void QuitActivity()
        {
            ballStand.DestroyBalls();
            manager.QuitActivity();
        }

        private void StartTheActivity()
        {
            ballStand.InstantiateBall(false);
            manager.StartActivity();
            foreach(BallAttractor ballAtractor in ballAttractors)
            {
                ballAtractor.gameObject.SetActive(true);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, actualPosition, 0.3f);
            //GetComponent<Renderer>().material.color = Color.red;

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
