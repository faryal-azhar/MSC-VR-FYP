using UnityEngine;

namespace KidsVR.Activities.Spelling
{
    [RequireComponent(typeof(AudioSource))]
    public class LaserGun : MonoBehaviour
    {
        [SerializeField] private GameObject laser;

        private AudioSource laserSound;

        private void Awake()
        {
            laserSound = GetComponent<AudioSource>();
        }

        public void StartFiring()
        {
            laser.SetActive(true);
            laserSound.Play();
        }

        public void StopFiring()
        {
            laser.SetActive(false);
            laserSound.Stop();
        }
    }
}
