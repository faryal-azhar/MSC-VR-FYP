using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class MusicPlayer : MonoBehaviour
    {
        AudioSource audioSource;
        
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayMusic(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
