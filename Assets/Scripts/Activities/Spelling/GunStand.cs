using UnityEngine;

namespace KidsVR.Activities.Spelling
{
    public class GunStand : MonoBehaviour
    {
        [SerializeField] private LaserGun gunPrefab;
        [SerializeField] private Transform spawnPoint;

        private LaserGun currentGun;

        public void SpawnGun()
        {
            if (currentGun != null)
            {
                Destroy(currentGun.gameObject);
            }

            currentGun = Instantiate(gunPrefab, spawnPoint.position, gunPrefab.transform.rotation);
        }
    }
}
