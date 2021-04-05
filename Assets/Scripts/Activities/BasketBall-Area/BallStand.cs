using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBallActivity
{
    public class BallStand : MonoBehaviour
    {
        public Ball ballPrefab;
        public Transform transformPoint;

        public void InstantiateBall()
        {
            Ball ballInstance= Instantiate(ballPrefab, transformPoint.position, Quaternion.identity);
            ballInstance.transform.parent = transformPoint;
            
            ballInstance.SetBallStand(this);
        }



    }
}
