using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorActivity.B_Color;

namespace ColorActivity
{
    [RequireComponent(typeof(B_Color))]
    public class Blocks : MonoBehaviour
    {
        Color32 blockColor;
        [SerializeField] ColorSpeaker colorSpeaker;
        bool speak = true;


        private void Start()
        {
            gameObject.SetActive(false);

        }
        public void DestroyBlock()
        {
            Destroy(this.gameObject);
        }
        public void SetBlockColor(BlockColor clr)
        {
            GetComponent<B_Color>().blockColor = clr;
            switch (clr)
            {
                case BlockColor.Blue://1
                    blockColor = Color.blue;
                    break;
                case BlockColor.Red://2
                    blockColor = Color.red;
                    break;
                case BlockColor.Pink://3
                    blockColor = new Color32(255, 105, 180, 255);
                    break;
                case BlockColor.Brown://4
                    blockColor = new Color32(139, 69, 19, 255);
                    break;
                case BlockColor.Purple://5
                    blockColor = new Color32(128, 0, 128, 255);
                    break;
                case BlockColor.Green://6
                    blockColor = Color.green;
                    break;
                case BlockColor.Yellow://7
                    blockColor = Color.yellow;
                    break;
                case BlockColor.Grey://8
                    blockColor = Color.grey;
                    break;
                case BlockColor.Orange://9
                    blockColor = new Color32(255, 165, 0, 255);
                    break;
            }
            GetComponent<MeshRenderer>().material.color = blockColor;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && speak)
            {
                speak = false;
                colorSpeaker.Speak(GetComponent<B_Color>().blockColor, transform.position);
                StartCoroutine(ResetSpeak());
            }
        }


        IEnumerator ResetSpeak()
        {
            yield return new WaitForSeconds(5f);
            speak = true;
        }


    }



}