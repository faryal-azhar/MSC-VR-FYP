using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorActivity.B_Color;

namespace ColorActivity
{
    public class ColorSpeaker : MonoBehaviour
    {
        [SerializeField]  AudioClip green;
        [SerializeField]  AudioClip blue;
        [SerializeField]  AudioClip yellow;
        [SerializeField]  AudioClip pink;
        [SerializeField]  AudioClip purple;
        [SerializeField]  AudioClip red;
        [SerializeField]  AudioClip grey;
        [SerializeField]  AudioClip orange;
        [SerializeField]  AudioClip brown;

        AudioSource audioSource;


        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Speak(BlockColor clr,Vector3 pos)
        {
            switch (clr)
            {
                case BlockColor.Blue://1
                    AudioSource.PlayClipAtPoint(blue,pos);
                    break;
                case BlockColor.Red://2
                    AudioSource.PlayClipAtPoint(red, pos);
                    break;
                case BlockColor.Pink://3
                    AudioSource.PlayClipAtPoint(pink, pos);
                    break;
                case BlockColor.Brown://4
                    AudioSource.PlayClipAtPoint(brown, pos);
                    break;
                case BlockColor.Purple://5
                    AudioSource.PlayClipAtPoint(purple, pos);
                    break;
                case BlockColor.Green://6
                    AudioSource.PlayClipAtPoint(green, pos);
                    break;
                case BlockColor.Yellow://7
                    AudioSource.PlayClipAtPoint(yellow, pos);
                    break;
                case BlockColor.Grey://8
                    AudioSource.PlayClipAtPoint(grey, pos);
                    break;
                case BlockColor.Orange://9
                    AudioSource.PlayClipAtPoint(orange, pos);
                    break;
            }


        }

    }
}
