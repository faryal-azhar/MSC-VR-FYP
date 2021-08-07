using UnityEngine;

namespace KidsVR.Core
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip defaultBackgroundMusic;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            PlayDefault();
        }

        public void Play(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }

        public void PlayDefault()
        {
            Play(defaultBackgroundMusic);
        }
    }
}
