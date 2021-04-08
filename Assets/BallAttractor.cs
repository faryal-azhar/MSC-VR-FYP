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
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Ball>())
            {
                ball = other.gameObject;
                forceDirction = (point.localPosition - ball.transform.localPosition);
                
                rb = ball.GetComponent<Rigidbody>();
                //rb.useGravity = false;
                move = true;
                rb.useGravity = false;
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            move = false;
            rb.useGravity = true;
        }

        private void FixedUpdate()
        {
            if (move && ball)
            {

                 forceDirction = (point.position - ball.transform.position);
                //check = Vector3.Slerp(ball.transform.localPosition, point.localPosition, 0.3f * Time.deltaTime);
                //var check1=ball.transform.TransformPoint(ball.transform.localPosition);
                //var check2 = point.TransformPoint(point.localPosition);

                Debug.Log(point.transform.position - ball.transform.position);
                ball.transform.rotation = Quaternion.Slerp(ball.transform.rotation, point.transform.rotation, 0.3f * Time.deltaTime);
                ball.transform.position=(Vector3.Slerp(ball.transform.position, point.position, 0.3f * Time.deltaTime)); 
                
                rb.AddForce(forceDirction.normalized * 900f * Time.deltaTime);
                if(forceDirction.magnitude <= 1f)
                    rb.useGravity = true;

                //if(
                //rb.velocity = forceDirction.normalized * 10f;
                //Debug.Log("working");
            }

        }
    }
}
