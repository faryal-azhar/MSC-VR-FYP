using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellingActivity
{
    public class DifficultySelector : MonoBehaviour
    {

        public Modes obj;
        private Modes[] modes;

        private void Start()
        {
            //modes =obj.GetComponents<Modes>();
        }

        public void PressEasy()
        {
            ActivateTheMode(obj.GetComponent<EasyMode>());
        }

        public void PressMedium()
        {
            ActivateTheMode(obj.GetComponent<MediumMode>());
        }

        public void PressHard()
        {
            ActivateTheMode(obj.GetComponent<HardMode>());
        }

        public void PressCuston()
        {
            ActivateTheMode(obj.GetComponent<CustomMode>());
        }

        private void ActivateTheMode(Modes mode)
        {
            foreach(Modes m in modes)
            {
                if (m == mode)
                {
                    m.enabled = true;
                }
                else
                {
                    m.enabled = false;
                }
            }
        }


    }
   
}
