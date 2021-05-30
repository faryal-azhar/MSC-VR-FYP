using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBallActivity
{
   
    public class BallAttractor : MonoBehaviour
    {
        GameObject ball;
        [SerializeField] Transform point;
        Vector3 forceDirction = Vector3.zero;
        [SerializeField] bool move = false;
        Rigidbody rb;
        [SerializeField] float slerpForce=10f;
        [SerializeField] float rbForce = 1000f;
        [SerializeField] float distanceToStop = 0.3f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Ball>())
            {
                ball = other.gameObject;
                forceDirction = (point.localPosition - ball.transform.localPosition);
                
                rb = ball.GetComponent<Rigidbody>();
                //rb.useGravity = false;
                move = true;
                //rb.useGravity = false;
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            move = false;
            //rb.useGravity = true;
        }

        private void FixedUpdate()
        {
            if (move && ball)
            {

                forceDirction = (point.position - ball.transform.position);
                var targetRotation = Quaternion.LookRotation(point.position - transform.position, Vector3.up);
                
                // ball.transform.rotation = Quaternion.Slerp(ball.transform.rotation, targetRotation, slerpForce * Time.deltaTime);
                ball.transform.LookAt(point);
                ball.transform.position=(Vector3.Slerp(ball.transform.position, point.position, slerpForce * Time.deltaTime));

                rb.AddRelativeForce(Vector3.forward * rbForce,ForceMode.Force);
 
                rb.MovePosition(forceDirction);


                if (Vector3.Distance(ball.transform.position,point.position)<distanceToStop)
                {
                   // rb.useGravity = true;
                    move = false;
                }

            }

        }
    }
}
