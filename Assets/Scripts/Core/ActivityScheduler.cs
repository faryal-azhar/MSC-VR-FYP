using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellingActivity;
using BasketBallActivity;

namespace Core
{
    public class ActivityScheduler : MonoBehaviour
    {
        IAction currentAction;
        [SerializeField] MusicPlayer musicPlayer;

        public void StartAction(IAction action,AudioClip audioClip)
        {
            if (currentAction != null)
            {
                Debug.Log($"Cancelling {currentAction}");
                currentAction.QuitActivity();
            }
            currentAction = action;
            musicPlayer.PlayMusic(audioClip);
        }

        public void ResetTheDefaultMusic()
        {
            musicPlayer.PlayDefaultMusic();
        }
    }

    
}
