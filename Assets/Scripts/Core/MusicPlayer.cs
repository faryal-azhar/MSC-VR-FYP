using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class MusicPlayer : MonoBehaviour
    {
        AudioSource audioSource;
        [SerializeField] AudioClip defaultBackgroundMusic;
        
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            PlayDefaultMusic();
        }

        public void PlayMusic(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void PlayDefaultMusic()
        {
            audioSource.Stop();
            audioSource.clip = defaultBackgroundMusic;
            audioSource.Play();
        }
    }
}
