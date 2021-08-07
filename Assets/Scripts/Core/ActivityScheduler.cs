using UnityEngine;

namespace KidsVR.Core
{
    // Makes sure only one activity is running at a time and plays its music.
    public class ActivityScheduler : MonoBehaviour
    {
        [SerializeField] private MusicPlayer musicPlayer;

        private IActivity currentActivity;

        public void Begin(IActivity activity, AudioClip music)
        {
            if (currentActivity == activity) return;

            if (currentActivity != null)
            {
                currentActivity.StopActivity();
            }

            currentActivity = activity;
            musicPlayer.Play(music);
        }

        public void End(IActivity activity)
        {
            if (currentActivity != activity) return;

            currentActivity = null;
            musicPlayer.PlayDefault();
        }
    }
}
