using System;
using System.Collections.Generic;
using UnityEngine;

namespace KidsVR.Activities.ColorSorting
{
    public class ColorSpeaker : MonoBehaviour
    {
        [Serializable]
        private struct ColorClip
        {
            public BlockColor color;
            public AudioClip clip;
        }

        [SerializeField] private ColorClip[] colorClips;

        private readonly Dictionary<BlockColor, AudioClip> clipsByColor = new Dictionary<BlockColor, AudioClip>();

        private void Awake()
        {
            foreach (ColorClip colorClip in colorClips)
            {
                clipsByColor[colorClip.color] = colorClip.clip;
            }
        }

        public void Speak(BlockColor color, Vector3 position)
        {
            if (clipsByColor.TryGetValue(color, out AudioClip clip))
            {
                AudioSource.PlayClipAtPoint(clip, position);
            }
        }
    }
}
