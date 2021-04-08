using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBallActivity
{
    public class BallStand : MonoBehaviour
    {
        public Ball ballPrefab;
        public Transform transformPoint;
        Ball ballInstance;
        bool force = false; // will be only true when call from BALL.. using becaude had to destroy ball
        public void InstantiateBall(bool val)
        {
            force = val;
            if (!ballInstance || force)
            {
                ballInstance = Instantiate(ballPrefab, transformPoint.position, Quaternion.identity);
                ballInstance.transform.parent = transformPoint;

                ballInstance.SetBallStand(this);
                force = false;

            }
            
        }

        public void DestroyBalls()
        {
            if (ballInstance)
            {
                ballInstance.DestroyBall(0f);
            }
        }



    }
}
