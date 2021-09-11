using UnityEngine;

namespace KidsVR.Activities.Basketball
{
    public class BallStand : MonoBehaviour
    {
        [SerializeField] private Ball ballPrefab;
        [SerializeField] private Transform spawnPoint;

        private Ball currentBall;
        private bool isActive;

        public void SpawnBall()
        {
            isActive = true;
            if (currentBall == null)
            {
                CreateBall();
            }
        }

        public void ReplaceBall()
        {
            if (isActive)
            {
                CreateBall();
            }
        }

        public void RemoveBall()
        {
            isActive = false;
            if (currentBall != null)
            {
                Destroy(currentBall.gameObject);
                currentBall = null;
            }
        }

        private void CreateBall()
        {
            currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            currentBall.SetStand(this);
        }
    }
}
