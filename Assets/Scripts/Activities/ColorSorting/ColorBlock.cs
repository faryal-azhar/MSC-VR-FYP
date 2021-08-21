using UnityEngine;

namespace KidsVR.Activities.ColorSorting
{
    // Says its color name when the player walks up to it.
    public class ColorBlock : ColoredObject
    {
        private const string PlayerTag = "Player";

        [SerializeField] private ColorSpeaker colorSpeaker;
        [SerializeField] private float speakCooldown = 5f;

        private float nextSpeakTime;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(PlayerTag) || Time.time < nextSpeakTime) return;

            nextSpeakTime = Time.time + speakCooldown;
            colorSpeaker.Speak(ColorType, transform.position);
        }
    }
}
