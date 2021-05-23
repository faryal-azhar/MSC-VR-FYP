using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
            DeactivateAllModes(obj.GetComponent<EasyMode>());
        }

        public void PressMedium()
        {
            DeactivateAllModes(obj.GetComponent<MediumMode>());
        }

        public void PressHard()
        {
            DeactivateAllModes(obj.GetComponent<HardMode>());
        }

        public void PressCuston()
        {
            DeactivateAllModes(obj.GetComponent<CustomMode>());
        }

        private void DeactivateAllModes(Modes mode)
        {
            foreach(Modes m in modes)
            {
                m.enabled = false;
            }
            mode.enabled = true;
            //modes.First(m => m == mode).enabled=true;     //will check
        }


    }
   
}
